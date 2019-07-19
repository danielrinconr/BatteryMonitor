using System.Deployment.Application;
using System.Reflection;
using System.Windows.Forms;

namespace BatteryMonitor.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout(string name, string version)
        {
            InitializeComponent();
            Text += name;
            LbVersion.Text = version;
        }

        private void LnkLbWebPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(LnkLbWebPage.Text);

        private void LnkLbEmailContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start($"mailto:{LnkLbEmailContact.Text}?subject={Text} v.{LbVersion.Text}");
    }
}