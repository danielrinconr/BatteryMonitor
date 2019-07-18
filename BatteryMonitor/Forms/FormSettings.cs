using BatteryMonitor.Utilities;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;

namespace BatteryMonitor.Forms
{
    public partial class FormSettings : Form
    {
        public bool HasChanges { get; private set; } = false;
        public uint TimeBattChk => (uint)NudTimeChk.Value;
        public uint AuxTimeBattChk => (uint)NudTimeNot.Value;
        public uint LowBattery => (uint)NudLowBattLevel.Value;
        public uint HighBattery => (uint)NudHighBattLevel.Value;
        public uint IdleTime => (uint)NudIdleTime.Value;
        public bool NotifyWind => ChkBNotifyWind.Checked;
        public bool NotifyVoice => ChkBNotifyVoice.Checked;

        private readonly Voice _voice;
        public string ChangeCurrentVoice => CbVoices.SelectedItem.ToString();
        public uint ChangeSyntVolume => (uint)TbTestVol.Value;
        public uint ChangeNotVolume => (uint)NudNotVol.Value;

        public string CurrenVoice => _voice.CurrenVoice;
        public uint NotifyVolume => _voice.NotVolume;

        public string PcName => TbPcName.Text;


        public FormSettings(uint timeBattChk, uint auxTimeBattChk, uint idleTime, uint lowBattery, uint highBattery, Voice voice, bool notifyWind, bool notifyVoice)
        {
            InitializeComponent();
            #region Not
            NudLowBattLevel.Value = lowBattery;
            NudHighBattLevel.Value = highBattery;
            NudTimeChk.Value = timeBattChk;
            NudTimeNot.Value = auxTimeBattChk;
            NudIdleTime.Value = idleTime;
            #endregion
            #region Voz
            _voice = voice;
            #endregion
            ChkBNotifyWind.Checked = notifyWind;
            ChkBNotifyVoice.Checked = notifyVoice;
            TbPcName.Text = voice.PcName;
            TbPcName.Text = PcName;
        }

        private void NotVol_ValueChanged(object sender, EventArgs e)
        {
            if (NudNotVol.Value == TbNotVol.Value) return;
            switch (sender)
            {
                case NumericUpDown ham:
                    TbNotVol.Value = (int)ham.Value;
                    break;

                case TrackBar ham:
                    NudNotVol.Value = ham.Value;
                    break;

                default:
                    MessageBox.Show($@"Control '{sender.GetType().Name}' no admitido", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void TestVol_ValueChanged(object sender, EventArgs e)
        {
            if (NudTestVol.Value == TbTestVol.Value) return;
            switch (sender)
            {
                case NumericUpDown ham:
                    TbTestVol.Value = (int)ham.Value;
                    break;

                case TrackBar ham:
                    NudTestVol.Value = ham.Value;
                    break;

                default:
                    MessageBox.Show($@"Control '{sender.GetType().Name}' no admitido", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            HasChanges = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();

        private void NudBattLevel_Validating(object sender, CancelEventArgs e)
        {
            if (!(NudLowBattLevel.Value < NudHighBattLevel.Value))
            {
                errorProvider1.SetError((NumericUpDown)sender,
                    "El valor del nivel de batería baja debe ser menor que el de batería alta");
                e.Cancel = true;
            }
            else if (errorProvider1.GetError((NumericUpDown)sender).Length > 0)
                errorProvider1.SetError((NumericUpDown)sender, string.Empty);
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                _voice.ChangeCurrentVoice(CbVoices.SelectedItem.ToString());
                _voice.ChangeSyntVolume(TbTestVol.Value);
                _voice.AddMessage(TbTest.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbTest_TextChanged(object sender, EventArgs e) => BtnRead.Enabled = TbTest.Text.Length > 0;

        private void FormSettings_Load(object sender, EventArgs e)
        {
            var voices = _voice.Voices;
            if (voices == null) return;
            var tbTestText = TbTest.Text;
            TbTest.Text = "";
            TbTest.Text = tbTestText;
            //Fill the Combo Box with available voices.
            // ReSharper disable once CoVariantArrayConversion
            CbVoices.Items.AddRange(voices.ToArray());
            //Select the spanish voice or the first.
            CbVoices.SelectedIndex = voices.FindIndex(x => x.Contains(_voice.CurrenVoice));
            //Concatenate the Numeric Up Down and Track bar value change event.
            NudTestVol.ValueChanged += TestVol_ValueChanged;
            TbTestVol.ValueChanged += TestVol_ValueChanged;
            NudNotVol.ValueChanged += NotVol_ValueChanged;
            TbNotVol.ValueChanged += NotVol_ValueChanged;
            //Set the Notification volume.
            NudNotVol.Value = _voice.NotVolume;
        }

        private void TbPcName_Validating(object sender, CancelEventArgs e)
        {
            if (TbPcName.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(TbPcName, "El nombre no puede quedar vacío. Especifique un nombre.");
            }
            else
            {
                if (errorProvider1.GetError(TbPcName).Length > 0) errorProvider1.Clear();
            }
        }

        private void ChkBNotifyTypes_CheckedChanged(object sender, EventArgs e)
        {
            GbNotifyTypes.GetNextControl((Control)sender, GbNotifyTypes.Controls[0] == (Control)sender).Focus();
        }

        private void ChkBNotifyTypes_Click(object sender, EventArgs e)
        {
            var chkNotify = (CheckBox)sender;
            var nextChkB = ((CheckBox)GbNotifyTypes.GetNextControl((Control)sender, GbNotifyTypes.Controls[0] == (Control)sender));
            if (chkNotify.Checked && !nextChkB.Checked)
            {
                //e.Cancel = true;
                errorProvider1.SetError(chkNotify, "Debe haber al menos un tipo de notificación.");
            }
            else
            {
                if (errorProvider1.GetError(chkNotify).Length > 0)
                    errorProvider1.SetError(chkNotify, string.Empty);
                if (errorProvider1.GetError(nextChkB).Length > 0)
                    errorProvider1.SetError(nextChkB, string.Empty);
                chkNotify.Checked = !chkNotify.Checked;
            }
        }
    }
}
