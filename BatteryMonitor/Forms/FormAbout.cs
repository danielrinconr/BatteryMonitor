using System.Deployment.Application;
using System.Reflection;
using System.Windows.Forms;

namespace BatteryMonitor.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, System.EventArgs e)
        {
            LbVersion.Text = ApplicationDeployment.IsNetworkDeployed ? $@"v{ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)}" : Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        //private void LinkLabel_DoubleClick(object sender, EventArgs e)
        //{
        //    Clipboard.SetText(((Label)sender).Text);
        //    MessageBox.Show(@"URL copiada al portapeles");
        //}        //private void LinkLabel_DoubleClick(object sender, EventArgs e)
        //{
        //    Clipboard.SetText(((Label)sender).Text);
        //    MessageBox.Show(@"URL copiada al portapeles");
        //}
    }
}