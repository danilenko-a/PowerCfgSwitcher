using System;
using System.Linq;
using System.Windows.Forms;
using PowerCfgSwitcher.Interfaces;

namespace PowerCfgSwitcher
{
    internal class NotifyIconBehavior
    {
        private readonly IContextMenuController powerCfgController;

        private readonly NotifyIcon notifyIcon = new NotifyIcon();

        private readonly ContextMenuImpl contextMenuImpl = new ContextMenuImpl();

        public NotifyIconBehavior(IContextMenuController powerCfgController)
        {
            this.powerCfgController = powerCfgController;

            this.notifyIcon.Icon = Properties.Resources.battery_4246;
            this.notifyIcon.Text = "Переключатель конфигураций";
            this.notifyIcon.Visible = true;
            this.notifyIcon.ContextMenu = contextMenuImpl;

            powerCfgController.CongifMenu(contextMenuImpl);

            contextMenuImpl.MenuItems.Cast<MenuItem>().ToList()
                .ForEach(x =>
                {
                    x.Click += MenuItem_Click;
                });

            contextMenuImpl.MenuItems.Add("Выход").Click += ExitItem_Click;

            contextMenuImpl.Popup += MenuStrip_Popup;
        }

        private void MenuStrip_Popup(object sender, EventArgs e)
        {
            powerCfgController.UpdateMenu(contextMenuImpl);
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
