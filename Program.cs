using System;
using System.Windows.Forms;

namespace PowerCfgSwitcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var diContainer = new DI.DiContainer();
            diContainer.Register<Interfaces.IContextMenuController, ContextMenuController>();
            diContainer.Register<NotifyIconBehavior, NotifyIconBehavior>();
            diContainer.Register<Interfaces.INotifyIcon, NotifyIconImpl>();
            diContainer.Register<Interfaces.IContextMenu, ContextMenuImpl>();

            var _ = diContainer.Resolve<NotifyIconBehavior>();

            Application.Run();
        }
    }
}
