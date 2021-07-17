using System;
using System.Linq;
using System.Windows.Forms;
using PowerCfgSwitcher.Interfaces;

namespace PowerCfgSwitcher
{
    internal class NotifyIconBehavior
    {
        private readonly IContextMenuController powerCfgController;

        private readonly INotifyIcon notifyIcon;

        private readonly IContextMenu contextMenu;

        public NotifyIconBehavior(IContextMenuController powerCfgController, INotifyIcon notifyIcon, IContextMenu contextMenu)
        {
            this.powerCfgController = powerCfgController;
            this.notifyIcon = notifyIcon;
            this.contextMenu = contextMenu;

            ConfigureNotifyIcon(notifyIcon, contextMenu);

            powerCfgController.CongifMenu(contextMenu);

            contextMenu.AddClickHandler(MenuItem_Click);

            contextMenu.AddMenuItem("Выход", ExitItem_Click);

            contextMenu.Popup += MenuStrip_Popup;
        }

        private void ConfigureNotifyIcon(INotifyIcon notifyIcon, IContextMenu contextMenu)
        {
            notifyIcon.Icon = Properties.Resources.battery_4246;
            notifyIcon.Text = "Переключатель конфигураций";
            notifyIcon.Visible = true;
            notifyIcon.ContextMenu = contextMenu;
        }

        private void MenuStrip_Popup(object sender, EventArgs e)
        {
            powerCfgController.UpdateMenu(contextMenu);
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var callback = ((dynamic)menuItem.Tag).callback as Action;

            callback?.Invoke();
        }
    }
}
