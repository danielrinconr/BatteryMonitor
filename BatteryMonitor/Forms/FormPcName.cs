using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryMonitor.Forms
{
    public partial class FormPcName : Form
    {
        public string PcName { get; private set; }
        public bool HasChange { get; private set; }
        public FormPcName(string pcName)
        {
            InitializeComponent();
            PcName = PcName;
            TbPcName.Text = pcName;
        }
        private void BtnAcept_Click(object sender, EventArgs e)
        {
            PcName = TbPcName.Text;
            HasChange = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();

        private void TbPcName_TextChanged(object sender, EventArgs e) => BtnAcept.Enabled = TbPcName.Text.Length > 0;
    }
}
