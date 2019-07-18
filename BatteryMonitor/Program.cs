using BatteryMonitor.Forms;
using System;
using System.Windows.Forms;

namespace BatteryMonitor
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(args.Length != 0));
        }
    }
}
