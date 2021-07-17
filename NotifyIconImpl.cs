using PowerCfgSwitcher.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace PowerCfgSwitcher
{
    internal class NotifyIconImpl : Interfaces.INotifyIcon
    {
        private readonly NotifyIcon notifyIcon = new NotifyIcon();

        public Icon Icon { set => this.notifyIcon.Icon = value; }

        public string Text { set => this.notifyIcon.Text = value; }

        public bool Visible { set => this.notifyIcon.Visible = value; }

        public IContextMenu ContextMenu { set => this.notifyIcon.ContextMenu = (ContextMenu)value; }

        public void Dispose()
        {
            notifyIcon.Dispose();
        }
    }
}