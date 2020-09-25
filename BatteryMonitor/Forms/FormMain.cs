using System;
using System.Deployment.Application;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BatteryMonitor.Properties;
using BatteryMonitor.Utilities;
using Microsoft.Win32;
//using Squirrel;
#region StaticEnums
using static BatteryMonitor.Forms.ModifyProgressBarColor;
using static BatteryMonitor.Utilities.Battery.Alerts;
#endregion

namespace BatteryMonitor.Forms
{
    public partial class FormMain : Form
    {
        #region Utilities
        public Voice Voice { get; set; }

        public Battery Battery { get; set; }

        public PcIdle PcIdle { get; set; }
        #endregion

        #region AutoRun
        private string AppName { get; set; }
        private string AppVersion { get; set; }
        #endregion

        /// <summary>
        /// Check idle time for voice notification.
        /// </summary>
        private bool IdleVoiceNotify { get; set; }

        private bool NotifyWind { get; set; }

        private bool NotifyVoice { get; set; }

        private uint TimeBatteryCheck { get; set; } = 1;

        private uint AuxTimeBatteryCheck { get; set; } = 1;

        /// <summary>
        /// Value for the progressbar.
        /// </summary>
        private int AuxAlertTime { get; set; } = 60;

        private readonly bool _startMinimized;

        /// <summary>
        /// Color to ProgressBar.
        /// </summary>
        public Colors PbColor { get; set; }

        // ReSharper disable once UnusedParameter.Local
        public FormMain(bool startMinimized)
        {
            InitializeComponent();
#if DEBUG
            // ReSharper disable once VirtualMemberCallInConstructor
            Text += @" (Debug)";
#endif
            _startMinimized = startMinimized;
            //CheckForUpdates();
        }

        //private async Task CheckForUpdates()
        //{
        //    using (var manager = new UpdateManager(@"E:\Documents\Daniel\Google_Drive\PROGRAMACIÓN\C#\BatteryMonitor\Releases"))
        //    {
        //        await manager.UpdateApp();
        //    }
        //}

        #region FormEvents

        private void FormMain_Load(object sender, EventArgs e)
        {
            Battery = new Battery();
            PcIdle = new PcIdle();
            //Battery.AddPowerModeChanged(PowerModeChanged);
            SystemEvents.PowerModeChanged += PowerModeChanged;
            ShowPowerStatus();
            BtnChecked.EnabledChanged += BtnChecked_EnabledChanged;

            // Get App Name and Version to show in the Form about.
            AppName = Assembly.GetExecutingAssembly().GetName().Name;
            AppVersion = ApplicationDeployment.IsNetworkDeployed ? $@"v{ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)}" : Assembly.GetExecutingAssembly().GetName().Version.ToString();

            try
            {
                Voice = new Voice(VoiceCompleted);
                BtnSpeak.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProperties();
            if (Battery.ChargeStatus == BatteryChargeStatus.NoSystemBattery)
            {
                NotifyIcon.Icon = Resources.ico_WithoutBatt;
                Icon = Resources.ico_WithoutBatt;
                return;
            }
#if !DEBUG
            Height = 390;
#endif
            TmCheckPower.Start();
        }

        private void LoadProperties()
        {
            //TODO: Change the place to get and set user settings, because when the app update it change to default.
            if (Settings.Default.PcName == string.Empty)
                ChangePcName(Environment.UserName);
            else
                Voice?.ChangePcName(Settings.Default.PcName);
            NotifyWind = Settings.Default.NotifyWind;
            NotifyVoice = Settings.Default.NotifyVoice;
            Battery.ChangeHighBatteryLvl(Settings.Default.BatteryHigh);
            Battery.ChangeLowBatteryLvl(Settings.Default.BatteryLow);
            Battery.ChangeAlertStatus(Array.ConvertAll(Settings.Default.AlertStatus.Split(','), bool.Parse));
            PcIdle.ChangeMaxIdleTime(Settings.Default.PcIdleTime);
            TimeBatteryCheck = Settings.Default.TimeBattChk;
            AuxTimeBatteryCheck = Settings.Default.TimeAuxBattChk;
            Voice?.ChangeNotVolume(Settings.Default.VolNot);
            if (Settings.Default.VoiceName != string.Empty)
                Voice?.ChangeCurrentVoice(Settings.Default.VoiceName);
            else
            {
                Settings.Default.VoiceName = Voice?.CurrentVoice;
                Settings.Default.Save();
            }
        }

        private void ChangePcName(string pcName)
        {
            var formPcName = new FormPcName(pcName);
            formPcName.ShowDialog();
            if (!formPcName.HasChange) return;
            Voice?.ChangePcName(formPcName.PcName);
            Settings.Default.PcName = formPcName.PcName;
            Settings.Default.Save();
        }

        private void BtnChecked_EnabledChanged(object sender, EventArgs e)
        {
            if (((Button)sender).Enabled)
                BtnChecked.BackColor = Color.FromArgb(0, 192, 0);
            else
            {
                BtnChecked.BackColor = SystemColors.Control;
                BtnChecked.UseVisualStyleBackColor = true;
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (!_startMinimized) return;
            WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.PowerModeChanged -= PowerModeChanged;
#if !DEBUG
            if (e.CloseReason == CloseReason.UserClosing)
                if (MessageBox.Show(@"¿Esta seguro de cerrar la apliación?", @"Cierre de aplicación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
#endif
            Voice?.Close();
        }

        private void FrmMain_Move(object sender, EventArgs e)
        {
            //Check when the app is minimized and hide it.
            if (WindowState != FormWindowState.Minimized) return;
            Hide();
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        #endregion FormEvents
        //TODO: Check the constant trigger event.
        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            //ShowPowerStatus();
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Battery.AuxAlert = false;
                    break;
                case PowerModes.StatusChange:
                    switch (Battery.ChargeStatus)
                    {
                        case BatteryChargeStatus.NoSystemBattery:
                            TmCheckPower.Stop();
                            TmWaitForResp.Stop();
                            //
                            var notifyIcon = Resources.ico_WithoutBatt;
                            NotifyIcon.Icon = notifyIcon;
                            Icon = notifyIcon;
                            break;
                        case BatteryChargeStatus.Charging:
                            if (!TmWaitForResp.Enabled) break;
                            TmWaitForResp.Stop();
                            TmCheckPower.Start();
                            break;
                        case BatteryChargeStatus.Unknown:
                        case BatteryChargeStatus.High:
                        case BatteryChargeStatus.Low:
                        case BatteryChargeStatus.Critical:
                        default:
                            //
                            //notifyIcon = Battery.IsCharging ? Resources.ico_chargingNormal : Resources.ico_DisconectNormal;
                            //
                            if (!TmWaitForResp.Enabled) break;
                            TmWaitForResp.Stop();
                            TmCheckPower.Start();
                            AlertChecked(false);
                            break;
                    }
                    break;
                case PowerModes.Suspend:
                    Voice.Checked();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ShowPowerStatus()
        {
            RefreshIconProgBar();
            var vol = (int)(Voice?.Volume ?? 0);
            TbVolume.Text = vol.ToString();
            //TODO: Update when it changes.
            LbAudioDevName.Text = Voice?.AudioDeviceName;
            var batteryLife = Battery.BatteryLifePercent;
            var percent = batteryLife.ToString("P0");
            NotifyIcon.Text = $@"{percent} {Battery.PowerLineStatus}";
            LbNivelCharge.Text = percent;
            ProgBarCharge.Value = (int)(batteryLife * 100);
            var chargeStatus = Battery.ChargeStatus;
            TbChargeStatus.Text = chargeStatus == 0 ? "Normal" : chargeStatus.ToString();
            //TbFullLifetime.Text = Battery.BatteryFullLifetime;
            TbLifeRemaining.Text = Battery.BatteryLifeRemaining;
            TbLineStatus.Text = Battery.PowerLineStatus;
        }

        /// <summary>
        /// Change the color of the progress bar and the Icons.
        /// </summary>
        private void RefreshIconProgBar()
        {
            var color = Colors.Green;
            var icon = Resources.ico_chargingNormal;
            switch (Battery.Alert)
            {
                case LowBattery:
                    {
                        color = Colors.Red;
                        icon = Battery.IsCharging ? Resources.ico_chargingLow : Resources.ico_DisconectLow;
                        break;
                    }
                case HighBattery when Battery.ChargeStatus != BatteryChargeStatus.NoSystemBattery:
                    {
                        color = Colors.Yellow;
                        icon = Battery.IsCharging ? Resources.ico_chargingHigh : Resources.ico_DisconectHigh;
                        break;
                    }
                case Any:
                    if (PbColor != Colors.Green)
                    {
                        color = Colors.Green;
                        icon = Battery.IsCharging ? Resources.ico_chargingNormal : Resources.ico_DisconectNormal;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            ProgBarCharge.SetState((int)(PbColor = color));
            NotifyIcon.Icon = icon;
            Icon = icon;
        }

        private void TmCheckPower_Tick(object sender, EventArgs e)
        {
            var idleTimeMin = PcIdle.GetIdleTimeMin();
            // Refresh Form data.
            ShowPowerStatus();
            TbIdleTime.Text = idleTimeMin.ToString("D");

            if (NotifyVoice && NotifyWind)
                // Check if activate Voice notification for idle time.
                IdleVoiceNotify = !NotifyWind || idleTimeMin >= PcIdle.MaxIdleTime;

            if (!Battery.CheckPowerLevel())
            {
                Battery.AuxAlert = false;
                return;
            }
            BtnSpeak.Enabled = false;
            if (Battery.AuxAlert && (Voice.AuxNotVolume += 10) > 100) Voice.AuxNotVolume = 100;
            NewNotification($"{Settings.Default.PcName}. {Battery.Msg}");
            TmCheckPower.Stop();
            TmWaitForResp.Start();
            GbNextNot.Enabled = true;
            Application.DoEvents();
        }

        private void TmWaitForResp_Tick(object sender, EventArgs e)
        {
            if (AuxAlertTime-- == 0)
            {
                // Reset time.
                AuxAlertTime = (int)(AuxTimeBatteryCheck * 60);
                TmWaitForResp.Stop();
                TmCheckPower.Start();
                return;
            }
            ShowPowerStatus();
            LbTime.Text = TimeSpan.FromSeconds(AuxAlertTime).ToString(@"mm\:ss");
            ProgBarNextAlert.Value = AuxAlertTime;
        }

        private void NewNotification(string msg)
        {
            BtnChecked.Enabled = true;
            if (NotifyWind) NotifyIcon.ShowBalloonTip(2000, "Notificación del estado de batería", msg, ToolTipIcon.Warning);
            if (!NotifyVoice) return;
            if (!IdleVoiceNotify) return;
            //Wait for NotifyWindow sound.
            Thread.Sleep(1000);
            Voice.AddMessage(Battery.Alert != LowBattery ?
                msg :
                msg + SpeakLifeRemaining(@"Tiempo Restante"));
        }

        private void BtnChecked_Click(object sender, EventArgs e) => AlertChecked(true);

        private void AlertChecked(bool cancelVoice)
        {
            try
            {
                if (NotifyVoice && cancelVoice) Voice.Checked();
                if (Battery.Checked() && NotifyWind)
                    NotifyIcon.ShowBalloonTip(1000, "Notificación del estado de batería", Battery.Msg, ToolTipIcon.Info);
                AuxAlertTime = (int)(AuxTimeBatteryCheck * 60);
                ProgBarNextAlert.Value = AuxAlertTime;
                LbTime.Text = TimeSpan.FromSeconds(AuxAlertTime).ToString(@"mm\:ss");
                TmWaitForResp.Stop();
                Battery.AuxAlert = false;
                if (!TmCheckPower.Enabled) TmCheckPower.Start();
                GbNextNot.Enabled = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        #region Speak Actions

        private void BtnSpeak_Click(object sender, EventArgs e) => SpeakInfo();

        private void SpeakInfo()
        {
            try
            {
                var msg = $@"Batería al {LbNivelCharge.Text}.";
                if (TbLifeRemaining.Text != @"--")
                    msg += SpeakLifeRemaining(@" Tiempo restante:");
                Voice.AddMessage(msg);
                if (!IdleVoiceNotify) return;
                BtnPause.Enabled = true;
                BtnSpeak.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SpeakLifeRemaining(string msg)
        {
            var remaining = TbLifeRemaining.Text.Split(':');
            var hour = Convert.ToInt16(remaining[0]);
            var min = Convert.ToInt16(remaining[1]);
            if (min <= 0) return msg;
            var hourTxt = "";
            var minTxt = min == 1 ? $"{min} minuto" : $"{min} minutos";
            if (hour > 0)
                hourTxt = hour == 1 ? $"{hour} hora" : $"{hour} horas";
            msg += $@" {hourTxt} {minTxt}";

            return msg;
            //NewNotification(msg);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!IdleVoiceNotify) return;
            Voice.Pause();
            BtnResume.Enabled = true;
            BtnPause.Enabled = false;
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            if (!IdleVoiceNotify) return;
            Voice.Resume();
            BtnPause.Enabled = true;
            BtnResume.Enabled = false;
        }

        private void VoiceCompleted() => Invoke(new Action(() =>
        {
            BtnPause.Enabled = false;
            BtnSpeak.Enabled = true;
        }));

        #endregion Speak Actions

        #region MenuStrip

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Fix the way to pass parameters.
            using (var formSettings = new FormSettings(TimeBatteryCheck, AuxTimeBatteryCheck, PcIdle.MaxIdleTime, Battery.LowBatteryLvl, Battery.HighBatteryLvl, Voice, NotifyWind, NotifyVoice, Battery.AlertStatus))
            {
                //Recall for check if there is an installed voice.
                Voice.GetVoices();
                // SHOW Form
                formSettings.ShowDialog();
                // Check if the user make any change.
                if (!formSettings.HasChanges) return;
                #region Notification
                //Stop timers.
                // Save the Status of the Timer.
                //var isTmCheckPowerEnabled = TmCheckPower.Enabled;
                AlertChecked(false);
                TmCheckPower.Stop();
                TmWaitForResp.Stop();
                //
                Battery.ChangeAlertStatus(new[] { formSettings.ChBoxLowBat, formSettings.ChBoxHighBat });
                Battery.ChangePrevAlert(Any);
                Battery.ResetAlert();
                //Get formSettings values.
                NotifyWind = formSettings.NotifyWind;
                NotifyVoice = formSettings.NotifyVoice;
                TimeBatteryCheck = formSettings.TimeBatChk;
                AuxTimeBatteryCheck = formSettings.AuxTimeBatChk;
                Battery.ChangeLowBatteryLvl(formSettings.LowBattery);
                Battery.ChangeHighBatteryLvl(formSettings.HighBattery);
                PcIdle.ChangeMaxIdleTime(formSettings.IdleTime);

                //Save in properties
                Settings.Default.BatteryHigh = Battery.HighBatteryLvl;
                Settings.Default.BatteryLow = Battery.LowBatteryLvl;
                Settings.Default.PcIdleTime = PcIdle.MaxIdleTime;
                Settings.Default.TimeBattChk = TimeBatteryCheck;
                Settings.Default.TimeAuxBattChk = AuxTimeBatteryCheck;
                Settings.Default.NotifyWind = NotifyWind;
                Settings.Default.NotifyVoice = NotifyVoice;
                Settings.Default.AlertStatus = string.Join(",", Battery.AlertStatus);
                //Changes timer intervals.
                TmCheckPower.Interval = (int)TimeBatteryCheck * 1000;
                AuxAlertTime = (int)(AuxTimeBatteryCheck * 60);
                ProgBarNextAlert.Maximum = AuxAlertTime;
                //Restart timers.
                //TmCheckPower.Enabled = isTmCheckPowerEnabled;
                TmCheckPower.Start();
                #endregion
                #region Voz
                try
                {
                    Settings.Default.VoiceName = formSettings.CurrentVoice;
                    Settings.Default.VolNot = formSettings.NotifyVolume;
                    Voice.ChangeCurrentVoice(formSettings.CurrentVoice);
                    Voice.ChangeNotVolume(formSettings.NotifyVolume);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                Voice?.ChangePcName(formSettings.PcName);
                Settings.Default.PcName = formSettings.PcName;
                Settings.Default.Save();
            }
        }

        #endregion MenuStrip

        #region ContextMenuStrip

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e) => SpeakInfo();

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => new FormAbout(AppName, AppVersion).ShowDialog();

        #endregion ContextMenuStrip

        private void NotifyIcon1_OnClick(object sender, EventArgs e)
        {
            if (!BtnChecked.Enabled) return;
            AlertChecked(true);
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e) => ShowForm();
    }

    public static class ModifyProgressBarColor
    {
        public enum Colors
        {
            Green = 1, Red, Yellow
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);

        public static void SetState(this ProgressBar pBar, int state) => SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
    }
}