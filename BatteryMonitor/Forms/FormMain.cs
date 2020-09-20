using System;
using System.Deployment.Application;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using BatteryMonitor.Properties;
using BatteryMonitor.Utilities;
using Microsoft.Win32;
//using Squirrel;
using static BatteryMonitor.Forms.ModifyProgressBarColor;
using static BatteryMonitor.Utilities.Battery.Alerts;

namespace BatteryMonitor.Forms
{
    public partial class FormMain : Form
    {
        #region Utilities
        public Voice Voice { get; set; }

        public Battery Battery { get; set; }

        public PcIdle PcIdle { get; set; }

        private RegistryKey Reg { get; set; }
        #endregion

        private string AppName { get; set; }
        private string AppVersion { get; set; }

        private string ApplicationPath { get; set; }

        /// <summary>
        /// Check idle time for voice notification.
        /// </summary>
        private bool IdleVoiceNotify { get; set; }

        private bool NotifyWind { get; set; }

        private bool NotifyVoice { get; set; }

        private uint TimeBatteryCheck { get; set; } = 1;

        private uint AuxTimeBatteryCheck { get; set; } = 1;

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
            _startMinimized = false;
#else
            _startMinimized = startMinimized;
#endif
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
            AutoRunLoad();
            Battery = new Battery();
            PcIdle = new PcIdle();
            //TODO: Move to Battery Class.
            SystemEvents.PowerModeChanged += PowerModeChanged;
            ShowPowerStatus();
            BtnChecked.EnabledChanged += BtnChecked_EnabledChanged;

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
                notifyIcon1.Icon = Resources.ico_WithoutBatt;
                Icon = Resources.ico_WithoutBatt;
                return;
            }

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
            Battery.changeAlertStatus(Array.ConvertAll(Settings.Default.AlertStatus.Split(','), bool.Parse));
            PcIdle.ChangeMaxIdleTime(Settings.Default.PcIdleTime);
            TimeBatteryCheck = Settings.Default.TimeBattChk;
            AuxTimeBatteryCheck = Settings.Default.TimeAuxBattChk;
            Voice?.ChangeNotVolume(Settings.Default.VolNot);
            if (Settings.Default.VoiceName != string.Empty)
                Voice?.ChangeCurrentVoice(Settings.Default.VoiceName);
            else
            {
                Settings.Default.VoiceName = Voice?.CurrenVoice;
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

        #region AutoRun
        /// <summary>
        /// Load the AutoRun status.
        /// </summary>
        private void AutoRunLoad()
        {
            AppName = Assembly.GetExecutingAssembly().GetName().Name;
            AppVersion = ApplicationDeployment.IsNetworkDeployed ? $@"v{ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)}" : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            ApplicationPath = Assembly.GetEntryAssembly()?.Location;
            var autoRun = Reg?.GetValue(AppName);
            if (ApplicationPath != null && autoRun != null) ChBAutoRun.Checked = autoRun.ToString() == ApplicationPath;
            ChBAutoRun.CheckStateChanged += ChBAutoRun_CheckStateChanged;
        }

        private void ChBAutoRun_CheckStateChanged(object sender, EventArgs e) => ChangeAutoRun(((CheckBox)sender).Checked);

        public void ChangeAutoRun(bool autoRun)
        {
            try
            {
                if (autoRun)
                    Reg.SetValue(AppName, ApplicationPath);
                else
                    Reg?.DeleteValue(AppName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion AutoRun

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            //TODO: Check if the next method is not necessary.
            //Battery.PowerModeChanged();
            ShowPowerStatus();
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Battery.AuxAlert = false;
                    break;
                case PowerModes.StatusChange:
                    switch (Battery.ChargeStatus)
                    {
                        case BatteryChargeStatus.NoSystemBattery:
                            TmCheckPower.Enabled = false;
                            TmWaitForResp.Enabled = false;
                            notifyIcon1.Icon = Resources.ico_WithoutBatt;
                            Icon = Resources.ico_WithoutBatt;
                            break;
                        case BatteryChargeStatus.Unknown:
                            TmCheckPower.Enabled = false;
                            TmWaitForResp.Enabled = false;
                            break;
                        case BatteryChargeStatus.High:
                            break;
                        case BatteryChargeStatus.Low:
                            break;
                        case BatteryChargeStatus.Critical:
                            break;
                        case BatteryChargeStatus.Charging:
                            break;
                        default:
                            var notifyIcon = Battery.IsCharging ? Resources.ico_chargingNormal : Resources.ico_DisconectNormal;
                            notifyIcon1.Icon = notifyIcon;
                            Icon = notifyIcon;
                            if (!TmCheckPower.Enabled)
                                TmCheckPower.Enabled = true;
                            Battery.AuxAlert = false;
                            break;
                    }

                    break;
                case PowerModes.Suspend:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ShowPowerStatus()
        {
            ChangeCharge();
            var chargeStatus = Battery.ChargeStatus;
            TbChargeStatus.Text = chargeStatus == 0 ? "Normal" : chargeStatus.ToString();
            TbFullLifetime.Text = Battery.BatteryFullLifetime;
            TbLifeRemaining.Text = Battery.BatteryLifeRemaining;
            TbLineStatus.Text = Battery.PowerLineStatus;
        }

        private void ChangeCharge()
        {
            var batteryLife = Battery.BatteryLifePercent;
            var percent = batteryLife.ToString("P0");
            notifyIcon1.Text = $@"{percent} {Battery.PowerLineStatus}";
            LbNivelCharge.Text = percent;
            batteryLife *= 100;
            PbCharge.Value = (int)batteryLife;
            if (batteryLife <= Battery.LowBatteryLvl)
            {
                PbColor = Colors.Red;
                PbCharge.SetState((int)PbColor);
                var notifyIcon = Battery.IsCharging ? Resources.ico_chargingLow : Resources.ico_DisconectLow;
                notifyIcon1.Icon = notifyIcon;
                Icon = notifyIcon;
            }
            else if (batteryLife >= Battery.HighBatteryLvl && Battery.ChargeStatus != BatteryChargeStatus.NoSystemBattery)
            {
                PbColor = Colors.Yellow;
                PbCharge.SetState((int)PbColor);
                var notifyIcon = Battery.IsCharging ? Resources.ico_chargingHigh : Resources.ico_DisconectHigh;
                notifyIcon1.Icon = notifyIcon;
                Icon = notifyIcon;
            }
            else if (PbColor != Colors.Green)
            {
                PbColor = Colors.Green;
                PbCharge.SetState((int)PbColor);
                var notifyIcon = Battery.IsCharging ? Resources.ico_chargingNormal : Resources.ico_DisconectNormal;
                notifyIcon1.Icon = notifyIcon;
                Icon = notifyIcon;
            }
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
                GbNextNot.Enabled = false;
                // Reset time.
                AuxAlertTime = (int)(AuxTimeBatteryCheck * 60);
                TmWaitForResp.Stop();
                TmCheckPower.Start();
                return;
            }
            LbTime.Text = TimeSpan.FromSeconds(AuxAlertTime).ToString(@"mm\:ss");
            //LbTime.Text = time.ToString(@"mm\:ss");
            PbNextAlert.Value = AuxAlertTime;
        }

        private void NewNotification(string msg)
        {
            BtnChecked.Enabled = true;
            if (NotifyWind) notifyIcon1.ShowBalloonTip(2000, "Notificación del estado de batería", msg, ToolTipIcon.Warning);
            if (!NotifyVoice) return;
            if (!IdleVoiceNotify) return;
            //Wait for NotifyWindow sound.
            Thread.Sleep(1000);
            Voice.AddMessage(Battery.Alert != LowBattery ?
                msg :
                msg + SpeakLifeRemaining(@"Tiempo Restante"));
        }

        private void BtnChecked_Click(object sender, EventArgs e) => AlertChecked();

        private void AlertChecked()
        {
            if (NotifyVoice) Voice.Checked();
            var hasWarningMsg = Battery.Checked();
            TmWaitForResp.Enabled = false;
            AuxAlertTime = (int)(AuxTimeBatteryCheck * 60);
            if (hasWarningMsg && NotifyWind)
                notifyIcon1.ShowBalloonTip(1000, "Notificación del estado de batería", Battery.Msg, ToolTipIcon.Info);
            BtnChecked.Enabled = false;
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
                TmCheckPower.Stop();
                TmWaitForResp.Stop();
                GbNextNot.Enabled = false;
                BtnChecked.Enabled = false;
                BtnSpeak.Enabled = true;
                //
                Battery.changeAlertStatus(new[] { formSettings.ChBoxLowBat, formSettings.ChBoxHighBat });
                Battery.ChangePrevAlert(Any);
                Battery.ResetAlert();
                //Get formSettings values.
                NotifyWind = formSettings.NotifyWind;
                NotifyVoice = formSettings.NotifyVoice;
                TimeBatteryCheck = formSettings.TimeBattChk;
                AuxTimeBatteryCheck = formSettings.AuxTimeBattChk;
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
                PbNextAlert.Maximum = AuxAlertTime;
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
            Voice.Checked();
            AlertChecked();
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e) => ShowForm();

        private void ChBAutoRun_CheckedChanged(object sender, EventArgs e)
        {

        }
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