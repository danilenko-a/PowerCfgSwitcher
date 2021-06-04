using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerCfgSwitcher
{
    static class Program
    {
        private static NotifyIconBehavior trayIcon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            var powerCfgController = new PowerCfgController();

            trayIcon = new NotifyIconBehavior(powerCfgController);

            Application.Run();
        }
    }
}
