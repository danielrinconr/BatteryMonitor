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

        //FIXME: Check if the after properties are used in AutoRun
        #region AutoRun
        //TODO: Use a multilanguage.
        /// <summary>
        /// App Name to deploy in Main and About Form.
        /// </summary>
        private string AppName { get; set; } = "Monitor de Batería";
        /// <summary>
        /// Show App Version in About Form.
        /// </summary>
        private string AppVersion { get; set; }
        #endregion

        /// <summary>
        /// Indicate if the system has some voice to speech.
        /// </summary>
        private bool HasAnyVoice { get; set; }

        /// <summary>
        /// Idle Flag for voice notification.
        /// </summary>
        private bool idleVoiceNotify;
        private bool IdleVoiceNotify
        {
            get { return idleVoiceNotify; }
            set
            {
                if (!HasAnyVoice)
                    throw new ArgumentNullException();
                idleVoiceNotify = value;
            }
        }

        /// <summary>
        /// Use Windows Notification.
        /// </summary>
        private bool NotifyWind { get; set; }

        /// <summary>
        /// Use Speech To Voice to notify.
        /// </summary>
        private bool notifyVoice;
        private bool NotifyVoice
        {
            get { return notifyVoice; }
            set
            {
                if (!HasAnyVoice)
                    throw new ArgumentNullException();
                notifyVoice = value;
            }
        }

        /// <summary>
        /// Time in minutes to check battery level.
        /// </summary>
        private uint TimeBatteryCheck { get; set; } = 1;

        /// <summary>
        /// Time in minutes to wait notify response.
        /// </summary>
        private uint AuxTimeBatteryCheck { get; set; } = 1;

        /// <summary>
        /// This is the value in seconds for the countdown Progressbar Wait Response.
        /// <para>
        /// Default: 60s
        /// </para>
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

        //--------------------------------------------------------------------------

        #region FormEvents
        private void FormMain_Load(object sender, EventArgs e)
        {
            #region Initialize Classes and properties

            Battery = new Battery();
            PcIdle = new PcIdle();

            // Get App Name and Version to show in the Form About.

            // This works only for Project Name (which is only in English).
            // AppName = Assembly.GetExecutingAssembly().GetName().Name;

            AppVersion = ApplicationDeployment.IsNetworkDeployed ? $@"v{ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)}" : Assembly.GetExecutingAssembly().GetName().Version.ToString();

            #endregion

            #region Concatenate Events
            //IDEA: Send Event Handle to Battery Class.
            //Battery.AddPowerModeChanged(PowerModeChanged);
            SystemEvents.PowerModeChanged += PowerModeChanged;
            ShowPowerStatus();

            // Event for check (omit) the notification.
            BtnChecked.EnabledChanged += BtnChecked_EnabledChanged;
            #endregion

            try
            {
                //Load available voices.
                Voice = new Voice(VoiceCompleted);
                HasAnyVoice = true;
                //Enable button to notify Battery level and current Power Mode.
                BtnSpeak.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Initialize secret manager to read runtime secret (keeps value only in memory).
            // This reads ENCRYPTION_CODE from environment variables if present.
            SecretManager.Initialize();

            //Load User Settings.
            LoadProperties();

            //Change icons if the PC has battery out.
            if (Battery.ChargeStatus == BatteryChargeStatus.NoSystemBattery)
            {
                NotifyIcon.Icon = Resources.ico_WithoutBatt;
                Icon = Resources.ico_WithoutBatt;
            }
            //Else begin monitoring.
            else
                TmCheckPower.Start();

#if DEBUG
            //Enable GroupBox with Debug info.
            GbDebugInfo.Visible = true;
#else
            //Change window height to hide the Debug Info GroupBox.
            Height -= GbDebugInfo.Size.Height;
#endif
        }

        /// <summary>
        /// <para>
        /// Load User Settings.
        /// </para>
        /// TODO: Don't use Settings Default Properties, because when the app update it change to default.
        /// </summary>
        private void LoadProperties()
        {
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

        /// <summary>
        /// Change PC Name (alias) to use in notifications.
        /// </summary>
        /// <param name="pcName">New name to PC</param>
        private void ChangePcName(string pcName)
        {
            //Create Form.
            var formPcName = new FormPcName(pcName);
            //Show Form as Dialog.
            formPcName.ShowDialog();
            //If the form has no changes, return.
            if (!formPcName.HasChange) return;

            //Change name in Voice class if exist.
            Voice?.ChangePcName(formPcName.PcName);

            //Save changes
            Settings.Default.PcName = formPcName.PcName;
            Settings.Default.Save();
        }

        /// <summary>
        /// Change color when the button is Enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChecked_EnabledChanged(object sender, EventArgs e)
        {
            //If the button is enables, the color change to green, else return to default button color.
            if (((Button)sender).Enabled)
                BtnChecked.BackColor = Color.FromArgb(0, 192, 0);
            else
            {
                BtnChecked.BackColor = SystemColors.Control;
                //REVIEW: Next line is unused.
                //BtnChecked.UseVisualStyleBackColor = true;
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //Minimize if the app was opened automatically.
            if (!_startMinimized) return;
            WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.PowerModeChanged -= PowerModeChanged;
            Voice?.Close();
#if !DEBUG
            if (e.CloseReason == CloseReason.UserClosing)
            //TODO: Change to YesNoCancel. Yes → close, No → minimize, Cancel → No action.
                if (MessageBox.Show(@"¿Esta seguro de cerrar la apliación?", @"Cierre de aplicación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
#endif
        }

        /// <summary>
        /// Check when the app is minimized and hide it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Move(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            Hide();
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        #endregion FormEvents

        //--------------------------------------------------------------------------

        //TODO: Check the constant trigger event.
        /// <summary>
        /// Event to control all Power Mode Changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        //The battery is out. Stop monitoring.
                        case BatteryChargeStatus.NoSystemBattery:
                            TmCheckPower.Stop();
                            TmWaitForResp.Stop();
                            //UGLY: Move next lines.
                            var notifyIcon = Resources.ico_WithoutBatt;
                            NotifyIcon.Icon = notifyIcon;
                            Icon = notifyIcon;
                            break;
                        //The charger is connected.
                        case BatteryChargeStatus.Charging:
                            //If has any notification, break.
                            if (!TmWaitForResp.Enabled) break;
                            //Stop timer for wait response.
                            TmWaitForResp.Stop();
                            //Start timer for Battery Monitoring.
                            TmCheckPower.Start();
                            break;
                        // ReSharper disable RedundantCaseLabel
                        case BatteryChargeStatus.Unknown:
                        case BatteryChargeStatus.High:
                        case BatteryChargeStatus.Low:
                        case BatteryChargeStatus.Critical:
                        // ReSharper restore RedundantCaseLabel
                        default:
                            if (!TmWaitForResp.Enabled) break;
                            TmWaitForResp.Stop();
                            TmCheckPower.Start();
                            AlertChecked(false);
                            break;
                    }
                    break;
                case PowerModes.Suspend:
                    //Omit the pending notifications.
                    Voice.Checked();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Update PowerStatus in Form Controls.
        /// </summary>
        private void ShowPowerStatus()
        {
#if DEBUG
            //Get the volume level if Voice class exist, else set 0.
            var vol = (int)(Voice?.Volume ?? 0);
            TbVolume.Text = vol.ToString();
            //TODO: Update when it changes ¿?.
            TbDeviceType.Text = Voice?.AudioDeviceName;
#endif
            RefreshIconAndProgBar();
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
        /// Change the color of the Progress Bar and the Icon.
        /// </summary>
        private void RefreshIconAndProgBar()
        {
            Colors color = Colors.Green;
            Icon icon = Resources.ico_chargingNormal;

            switch (Battery.Alert)
            {
                case LowBattery:
                    {
                        color = Colors.Red;
                        icon = Battery.IsCharging ? Resources.ico_chargingLow : Resources.ico_DisconnectLow;
                        break;
                    }
                case HighBattery when Battery.ChargeStatus != BatteryChargeStatus.NoSystemBattery:
                    {
                        color = Colors.Yellow;
                        icon = Battery.IsCharging ? Resources.ico_chargingHigh : Resources.ico_DisconnectHigh;
                        break;
                    }
                case Any:
                    if (PbColor != Colors.Green)
                    {
                        color = Colors.Green;
                        icon = Battery.IsCharging ? Resources.ico_chargingNormal : Resources.ico_DisconnectNormal;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            ProgBarCharge.SetState((int)(PbColor = color));
            NotifyIcon.Icon = icon;
            Icon = icon;
        }

        /// <summary>
        /// Timer to Check Power Battery Levels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmCheckPower_Tick(object sender, EventArgs e)
        {
            var idleTimeMin = PcIdle.GetIdleTimeMin();

            // Refresh data.
            TbIdleTime.Text = idleTimeMin.ToString("D");
            ShowPowerStatus();

            // Check Battry Level. If return false, Flag down and return.
            if (!Battery.CheckPowerLevel())
            {
                Battery.AuxAlert = false;
                return;
            }

            // Check if enable Voice Notification for idle time.
            if (NotifyVoice && NotifyWind)
                IdleVoiceNotify = idleTimeMin >= PcIdle.MaxIdleTime;

            // Increase volumen.
            if (Battery.AuxAlert && (Voice.AuxNotVolume += 10) > 100)
                Voice.AuxNotVolume = 100;

            // Deploy new notification.
            NewNotification($"{Settings.Default.PcName}. {Battery.Msg}");

            // Stop this timer.
            // NOTE: The battery level will be update in TmWaitForResp
            TmCheckPower.Stop();

            // Start Timer for wait response.
            TmWaitForResp.Start();

            GbVoiceBtns.Enabled = false;
            GbNextNot.Enabled = true;
            Application.DoEvents();
        }

        /// <summary>
        /// Timer to wait for response to a notification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //Update data Form.
            ShowPowerStatus();
            TbIdleTime.Text = PcIdle.GetIdleTimeMin().ToString("D");
            LbTime.Text = TimeSpan.FromSeconds(AuxAlertTime).ToString(@"mm\:ss");
            ProgBarWaitResponse.Value = AuxAlertTime;
        }

        private void NewNotification(string msg)
        {
            //Enable button to omit notification.
            BtnChecked.Enabled = true;

            if (NotifyWind)
            {
                NotifyIcon.ShowBalloonTip(2000, @"Notificación del estado de batería", msg, ToolTipIcon.Warning);

                //Wait for NotifyWindow sound.
                Thread.Sleep(1000);
            }

            if (!NotifyVoice) return;
            if (!IdleVoiceNotify) return;

            // If the notification is for LowBattery, add remaining time to speech.
            Voice.AddMessage(Battery.Alert != LowBattery ?
                msg :
                msg + GetLifeRemainingStr(@"Tiempo Restante"));
        }

        private void BtnChecked_Click(object sender, EventArgs e) => AlertChecked(true);

        private void AlertChecked(bool cancelVoice)
        {
            try
            {
                if (NotifyVoice && cancelVoice) Voice.Checked();
                if (Battery.Checked() && NotifyWind)
                    NotifyIcon.ShowBalloonTip(1000, @"Notificación del estado de batería", Battery.Msg, ToolTipIcon.Info);
                AuxAlertTime = (int)(AuxTimeBatteryCheck * 60);
                ProgBarWaitResponse.Value = AuxAlertTime;
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
                var msg = $"Batería al {LbNivelCharge.Text}.";
                if (TbLifeRemaining.Text != @"--")
                    msg += GetLifeRemainingStr(@" Tiempo restante:");
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

        /// <summary>
        /// Get Battery Life Remaining in text.
        /// </summary>
        /// <param name="msg">Before text</param>
        /// <returns>Battery Life Remaining in text
        /// <para>
        /// Ex: Remaining time 30 minuts.
        /// </para>
        /// </returns>
        private string GetLifeRemainingStr(string msg)
        {
            var remaining = TbLifeRemaining.Text.Split(':');

            if (!short.TryParse(remaining[0], out short hour) ||
                !short.TryParse(remaining[1], out short min))
                return string.Empty;

            if (min <= 0) return string.Empty;
            var hourTxt = "";
            var minTxt = min == 1 ? $"{min} minuto" : $"{min} minutos";
            if (hour > 0)
                hourTxt = hour == 1 ? $"{hour} hora" : $"{hour} horas";
            msg += $@" {hourTxt} {minTxt}";

            return msg;
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
                ProgBarWaitResponse.Maximum = AuxAlertTime;
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

        private void BtnTest1_Click(object sender, EventArgs e)
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