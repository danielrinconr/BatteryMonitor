using System;
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

namespace BatteryMonitor.Forms
{
    public partial class FormMain : Form
    {
        public Voice Voice { get; set; }

        public Battery Battery { get; set; }

        public PcInnactivity PcInnactivity { get; set; }

        private RegistryKey Reg { get; set; }

        private const string ApplicationName = "BatteryMonitor";

        private string ApplicationPath { get; set; }

        private bool VoiceNotify { get; set; }

        private uint TimeBattChk { get; set; } = 1;

        private uint AuxTimeBattChk { get; set; } = 1;

        private uint AuxAlertTime { get; set; } = 60;

        private readonly bool _show;

        public Colors PbColor;

        public FormMain(bool show)
        {
            InitializeComponent();
            _show = show;
#pragma warning disable 4014
            //CheckForUpdates();
#pragma warning restore 4014
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
            PcInnactivity = new PcInnactivity();
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

            LoadPropeties();
            if (Math.Abs(Battery.BatteryLifePercent - 1) < 0.001 && TbChargeStatus.Text == @"NoSystemBattery")
                return;
            TmCheckPower.Start();
        }

        private void LoadPropeties()
        {
            if (Settings.Default.PcName == string.Empty)
                ChangePcName(Environment.UserName);
            else
                Voice?.ChangePcName(Settings.Default.PcName);
            Battery.ChangeHighBattLevel(Settings.Default.BatteryHigh);
            Battery.ChangeLowBattLevel(Settings.Default.BatteryLow);
            PcInnactivity.ChangeMaxIdleTime(Settings.Default.PcIdleTime);
            TimeBattChk = Settings.Default.TimeBattChk;
            AuxTimeBattChk = Settings.Default.TimeAuxBattChk;
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
            if (_show) return;
            WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (MessageBox.Show(@"¿Esta seguro de cerrar la apliación?", @"Cierre de aplicación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

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

        private void AutoRunLoad()
        {
            Reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            var autoRun = Reg?.GetValue(ApplicationName) != null;
            ChBAutoRun.Checked = autoRun;
            ChBAutoRun.CheckStateChanged += ChBAutoRun_CheckStateChanged;
            ApplicationPath = Assembly.GetEntryAssembly()?.Location;
        }

        private void ChBAutoRun_CheckStateChanged(object sender, EventArgs e) => ChangeAutoRun(((CheckBox)sender).Checked);

        public void ChangeAutoRun(bool autoRun)
        {
            try
            {
                if (autoRun)
                    Reg.SetValue(ApplicationName, $"{ApplicationPath} auto");
                else
                    Reg?.DeleteValue(ApplicationName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion AutoRun

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            ShowPowerStatus();
            Battery.PowerModeChanged();
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Battery.PrevAlert = Battery.Alerts.Any;
                    break;
                case PowerModes.StatusChange:
                    if (!Battery.IsCharging) break;
                    var ham = Math.Abs(Battery.BatteryLifePercent - 1) < 0.001 && Battery.ChargeStatus == BatteryChargeStatus.NoSystemBattery;
                    TmCheckPower.Enabled = !ham;
                    TmWaitForResp.Enabled = !ham;
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
            if (batteryLife <= Battery.LowBattLevel)
            {
                PbColor = Colors.Red;
                PbCharge.SetState((int)PbColor);
            }
            else if (batteryLife >= Battery.HighBattLevel)
            {
                PbColor = Colors.Yellow;
                PbCharge.SetState((int)PbColor);
            }
            else if (PbColor != Colors.Green)
            {
                PbColor = Colors.Green;
                PbCharge.SetState((int)PbColor);
            }
        }

        private void TmCheckPower_Tick(object sender, EventArgs e)
        {
            ShowPowerStatus();
            var idleTimeMin = PcInnactivity.GetIdleTimeMin();
            VoiceNotify = idleTimeMin >= PcInnactivity.MaxIdleTime;
            TbIdleTime.Text = idleTimeMin.ToString("D");
            if (!Battery.CheckPowerLevel())
            {
                if (!BtnChecked.Enabled || Battery.Alert != Battery.Alerts.Any) return;
                if (!Voice.IsSpeaking) AlertChecked();
                Battery.AuxAlert = false;
                return;
            }

            var batteryMsg = Battery.Msg;
            if (Battery.Alert == Battery.Alerts.LowBattery)
                batteryMsg += SpeakLifeRemaining(@" Tiempo restante:");
            BtnSpeak.Enabled = false;
            NewNotification($"{Settings.Default.PcName}. {batteryMsg}");
            TmWaitForResp.Enabled = true;
            Application.DoEvents();
        }

        private void TmWaitForResp_Tick(object sender, EventArgs e)
        {
            if (AuxAlertTime-- == 0)
            {
                AuxAlertTime = AuxTimeBattChk * 60;
                TmWaitForResp.Enabled = false;
                Battery.WaitForResp();
                return;
            }
            var time = TimeSpan.FromSeconds(AuxAlertTime);
            LbTime.Text = time.ToString(@"mm\:ss");
            PbNextAlert.Value = (int)AuxAlertTime;
        }

        private void NewNotification(string msg)
        {
            BtnChecked.Enabled = true;
            notifyIcon1.ShowBalloonTip(1000, "Notificación del estado de batería", msg, ToolTipIcon.Info);
            if (!VoiceNotify) return;
            Thread.Sleep(1000);
            Voice.AddMessage(msg);
        }

        private void BtnChecked_Click(object sender, EventArgs e)
        {
            Voice.Checked();
            AlertChecked();
        }

        private void AlertChecked()
        {
            var _checked = Battery.Checked();
            TmWaitForResp.Enabled = false;
            AuxAlertTime = AuxTimeBattChk * 60;
            if (!_checked)
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
                if (!VoiceNotify) return;
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
            var hourtxt = "";
            var mintxt = min == 1 ? $"{min} minuto" : $"{min} minutos";
            if (hour > 0)
                hourtxt = hour == 1 ? $"{hour} hora" : $"{hour} horas";
            msg += $@" {hourtxt} {mintxt}";

            return msg;
            //NewNotification(msg);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!VoiceNotify) return;
            Voice.Pause();
            BtnResume.Enabled = true;
            BtnPause.Enabled = false;
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            if (!VoiceNotify) return;
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
            Voice.GetVoices();
            var formSettings = new FormSettings(TimeBattChk, AuxTimeBattChk, PcInnactivity.MaxIdleTime, Battery.LowBattLevel, Battery.HighBattLevel, Voice);
            formSettings.ShowDialog();
            if (!formSettings.HasChanges) return;
            #region Notification
            //Stop timers.
            var isTmCheckPowerEnabled = TmCheckPower.Enabled;
            TmCheckPower.Stop();
            TmWaitForResp.Stop();
            //Get formSettings values.
            TimeBattChk = formSettings.TimeBattChk;
            AuxTimeBattChk = formSettings.AuxTimeBattChk;
            Battery.ChangeLowBattLevel(formSettings.LowBattery);
            Battery.ChangeHighBattLevel(formSettings.HighBattery);
            Battery.PrevAlert = Battery.Alerts.Any;
            PcInnactivity.ChangeMaxIdleTime(formSettings.IdleTime);
            //Save in properties
            Settings.Default.BatteryHigh = Battery.HighBattLevel;
            Settings.Default.BatteryLow = Battery.LowBattLevel;
            Settings.Default.PcIdleTime = PcInnactivity.MaxIdleTime;
            Settings.Default.TimeBattChk = TimeBattChk;
            Settings.Default.TimeAuxBattChk = AuxTimeBattChk;
            //Changes timer intervals.
            TmCheckPower.Interval = (int)TimeBattChk * 1000;
            AuxAlertTime = AuxTimeBattChk * 60;
            PbNextAlert.Maximum = (int)AuxAlertTime;
            //Restart timers.
            TmCheckPower.Enabled = isTmCheckPowerEnabled;
            #endregion
            #region Voz
            try
            {
                //Recall for check if ther is an installed voice.
                Settings.Default.VoiceName = formSettings.CurrenVoice;
                Settings.Default.VolNot = formSettings.NotVolume;
                Voice.ChangeCurrentVoice(formSettings.CurrenVoice);
                Voice.ChangeNotVolume(formSettings.NotVolume);
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

        #endregion MenuStrip

        #region ContextMenuStrip

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void InformeToolStripMenuItem_Click(object sender, EventArgs e) => SpeakInfo();

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => new FormAbout().ShowDialog();

        #endregion ContextMenuStrip

        private void NotifyIcon1_OnClick(object sender, EventArgs e)
        {
            if (!BtnChecked.Enabled) return;
            Voice.Checked();
            AlertChecked();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) => ShowForm();
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