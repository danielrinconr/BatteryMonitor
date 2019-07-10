using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
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
        public Voice Voice;
        public Battery Battery;
        public PcInnactivity PcInnactivity;

        private RegistryKey _reg;
        private const string ApplicationName = "BatteryMonitor";
        private string _applicationPath;

        private bool VoiceNotify { get; set; }

        private uint _timeBattChk = 1;
        private uint _auxTimeBattChk = 1;
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
            TmCheckPower.Start();
        }

        private void LoadPropeties()
        {
            Battery.ChangeHighBattLevel(Settings.Default.BatteryHigh);
            Battery.ChangeLowBattLevel(Settings.Default.BatteryLow);
            PcInnactivity.ChangeMaxIdleTime(Settings.Default.PcIdleTime);
            _timeBattChk = Settings.Default.TimeBattChk;
            _auxTimeBattChk = Settings.Default.TimeAuxBattChk;
            Voice?.ChangeNotVolume(Settings.Default.VolNot);
            if (Settings.Default.VoiceName != string.Empty)
                Voice?.ChangeCurrentVoice(Settings.Default.VoiceName);
            else
            {
                Settings.Default.VoiceName = Voice?.CurrenVoice;
                Settings.Default.Save();
            }
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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) => Voice?.Close();

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
            _reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            var autoRun = _reg?.GetValue(ApplicationName) != null;
            ChBAutoRun.Checked = autoRun;
            ChBAutoRun.CheckStateChanged += ChBAutoRun_CheckStateChanged;
            _applicationPath = Assembly.GetEntryAssembly()?.Location;
        }

        private void ChBAutoRun_CheckStateChanged(object sender, EventArgs e) => ChangeAutoRun(((CheckBox)sender).Checked);

        public void ChangeAutoRun(bool autoRun)
        {
            try
            {
                if (autoRun)
                    _reg.SetValue(ApplicationName, $"{_applicationPath} auto");
                else
                    _reg?.DeleteValue(ApplicationName);
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
            if (Battery.IsCharging && Battery.Alert == Battery.Alerts.LowBattery)
                AlertChecked();

            if (!Battery.IsCharging && Battery.Alert == Battery.Alerts.HighBattery)
                AlertChecked();
        }

        private void ShowPowerStatus()
        {
            ChangeCharge();
            TbChargeStatus.Text = Battery.ChargeStatus;
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
            if (batteryLife < Battery.LowBattLevel)
            {
                PbColor = Colors.Red;
                PbCharge.SetState((int)PbColor);
            }
            else if (batteryLife > Battery.HighBattLevel)
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
                if (BtnChecked.Enabled && Battery.Alert == Battery.Alerts.Any)
                    BtnChecked.Enabled = false;
                return;
            }
            NewNotification(Battery.Msg);
            if (Battery.Alert == Battery.Alerts.LowBattery) SpeakLifeRemaining(@"Tiempo restante:");
            TmWaitForResp.Enabled = true;
        }

        private void TmWaitForResp_Tick(object sender, EventArgs e)
        {
            Battery.WaitForResp();
            TmWaitForResp.Enabled = false;
        }

        private void NewNotification(string msg)
        {
            BtnChecked.Enabled = true;
            if (VoiceNotify)
                Voice.AddMessage(msg);
            notifyIcon1.ShowBalloonTip(1000, "Notificación del estado de batería", msg, ToolTipIcon.Info);
        }

        private void BtnChecked_Click(object sender, EventArgs e) => AlertChecked();

        private void AlertChecked()
        {
            var _checked = Battery.Checked();
            TmWaitForResp.Enabled = false;
            if (!_checked)
                NewNotification(Battery.Msg);
            BtnChecked.Enabled = false;
        }

        #region Speak Actions

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            SpeakInfo();
        }

        private void SpeakInfo()
        {
            try
            {
                //NewNotification($@"Batería al {txtCharge.Text}");
                Voice.AddMessage($@"Batería al {LbNivelCharge.Text}.");

                if (TbLifeRemaining.Text != @"--")
                    SpeakLifeRemaining(@"Tiempo restante:");
                if (!VoiceNotify) return;
                BtnPause.Enabled = true;
                BtnSpeak.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SpeakLifeRemaining(string msg)
        {
            var remaining = TbLifeRemaining.Text.Split(':');
            var hour = Convert.ToInt16(remaining[0]);
            var min = Convert.ToInt16(remaining[1]);
            if (min > 0)
            {
                var hourtxt = "";
                var mintxt = min == 1 ? $"{min} minuto" : $"{min} minutos";
                if (hour > 0)
                    hourtxt = hour == 1 ? $"{hour} hora" : $"{hour} horas";
                msg += $@"{hourtxt} {mintxt}";
            }
            NewNotification(msg);
            //Voice.AddMessage(msg);
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

        private void VoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Recall for check if ther is an installed voice.
                Voice.GetVoices();
                var voiceSettings = new FormVoiceSettings(Voice);
                voiceSettings.ShowDialog();
                if (!voiceSettings.Changes) return;
                Settings.Default.VoiceName = voiceSettings.CurrenVoice;
                Settings.Default.VolNot = voiceSettings.NotVolume;
                Settings.Default.Save();
                Voice.ChangeCurrentVoice(voiceSettings.CurrenVoice);
                Voice.ChangeNotVolume(voiceSettings.NotVolume);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNotSetTime = new FormNotSetTime(_timeBattChk, _auxTimeBattChk, PcInnactivity.MaxIdleTime, Battery.LowBattLevel, Battery.HighBattLevel);
            frmNotSetTime.ShowDialog();
            if (!frmNotSetTime.Changes) return;
            //Stop timers.
            TmCheckPower.Stop();
            TmWaitForResp.Stop();
            //Get frmNotSetTime values.
            _timeBattChk = frmNotSetTime.TimeBattChk;
            _auxTimeBattChk = frmNotSetTime.AuxTimeBattChk;
            Battery.ChangeLowBattLevel(frmNotSetTime.LowBattery);
            Battery.ChangeHighBattLevel(frmNotSetTime.HighBattery);
            PcInnactivity.ChangeMaxIdleTime(frmNotSetTime.IdleTime);
            //Save in properties
            Settings.Default.BatteryHigh = Battery.HighBattLevel;
            Settings.Default.BatteryLow = Battery.LowBattLevel;
            Settings.Default.PcIdleTime = PcInnactivity.MaxIdleTime;
            Settings.Default.TimeBattChk = _timeBattChk;
            Settings.Default.TimeAuxBattChk = _auxTimeBattChk;
            Settings.Default.Save();
            //Changes timer intervals.
            TmCheckPower.Interval = (int)_timeBattChk * 1000;
            TmWaitForResp.Interval = (int)_auxTimeBattChk * 60000;
            //Restart timers.
            TmCheckPower.Start();
            TmWaitForResp.Start();
        }

        #endregion MenuStrip

        #region ContextMenuStrip

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void InformeToolStripMenuItem_Click(object sender, EventArgs e) => SpeakInfo();

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => new FormAbout().ShowDialog();

        #endregion ContextMenuStrip

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => ShowForm();
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