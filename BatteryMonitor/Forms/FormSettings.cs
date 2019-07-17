using BatteryMonitor.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryMonitor
{
    public partial class FormSettings : Form
    {
        public bool HasChanges { get; internal set; }
        public uint TimeBattChk { get; internal set; }
        public uint AuxTimeBattChk { get; internal set; }
        public uint LowBattery { get; internal set; }
        public uint HighBattery { get; internal set; }
        public uint IdleTime { get; internal set; }

        private readonly Voice _voice;
        public string CurrenVoice => _voice.CurrenVoice;
        public uint NotVolume => _voice.NotVolume;

        public FormSettings(uint timeBattChk, uint auxTimeBattChk, uint idleTime, uint lowBattery, uint highBattery, Voice voice)
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
            TimeBattChk = (uint)NudTimeChk.Value;
            AuxTimeBattChk = (uint)NudTimeNot.Value;
            IdleTime = (uint)NudIdleTime.Value;
            LowBattery = (uint)NudLowBattLevel.Value;
            HighBattery = (uint)NudHighBattLevel.Value;

            _voice.ChangeCurrentVoice(CbVoices.SelectedItem.ToString());
            _voice.ChangeSyntVolume(TbTestVol.Value);
            _voice.ChangeNotVolume((uint)NudNotVol.Value);

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
    }
}
