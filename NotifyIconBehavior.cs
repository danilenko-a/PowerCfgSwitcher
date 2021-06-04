using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerCfgSwitcher
{
    internal class NotifyIconBehavior
    {
        private readonly PowerCfgController powerCfgController;

        private readonly NotifyIcon notifyIcon = new NotifyIcon();

        private readonly ContextMenu menuStrip = new ContextMenu();

        public NotifyIconBehavior(PowerCfgController powerCfgController)
        {
            this.powerCfgController = powerCfgController;

            this.notifyIcon.Icon = Properties.Resources.battery_4246;
            this.notifyIcon.Text = "Переключатель конфигураций";
            this.notifyIcon.Visible = true;
            this.notifyIcon.ContextMenu = menuStrip;
            //this.notifyIcon.MouseClick += NotifyIcon_MouseClick;

            powerCfgController.CongifMenu(menuStrip);

            menuStrip.MenuItems.Cast<MenuItem>().ToList()
                .ForEach(x =>
                {
                    x.Click += MenuItem_Click;
                });

            menuStrip.MenuItems.Add("Выход").Click += ExitItem_Click;

            menuStrip.Popup += MenuStrip_Popup;
        }

        //private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        //{
        //    var menuString = new ContextMenuStrip();
        //    menuString.Items.Add("sdfsdf");
        //    //notifyIcon.ContextMenuStrip = menuString;

        //    SetForegroundWindow(new HandleRef(notifyIcon, menuString.Handle));

        //    int x = Control.MousePosition.X;
        //    int y = Control.MousePosition.Y;
        //    //x = x - 10;
        //    //y = y - 40;
        //    menuString.Show(x, y);
        //}

        [DllImport("User32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        private void MenuStrip_Popup(object sender, EventArgs e)
        {
            powerCfgController.UpdateMenu(menuStrip);
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var configGuid = menuItem.Tag?.ToString();
            if (configGuid == null) return;
            powerCfgController.SetActive(configGuid);
        }
    }
}
