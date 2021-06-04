using System;
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
            var powerCfgController = new ContextMenuController();
            trayIcon = new NotifyIconBehavior(powerCfgController);

            Application.Run();
        }
    }
}
