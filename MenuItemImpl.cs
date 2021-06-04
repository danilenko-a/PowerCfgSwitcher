using System;
using System.Windows.Forms;

namespace PowerCfgSwitcher.Interfaces
{
    internal class MenuItemImpl : IMenuItem
    {
        private readonly MenuItem menuItem;

        public MenuItemImpl(MenuItem menuItem)
        {
            this.menuItem = menuItem;
        }

        public Guid Guid => ((dynamic)menuItem.Tag).guid;

        public Action Callback
        {
            get { return ((dynamic)menuItem.Tag).callback; }
            set { menuItem.Tag = new { guid = Guid, callback = value }; }
        }

        public bool Checked
        {
            get
            {
                return menuItem.Checked;
            }

            set
            {
                menuItem.Checked = value;
            }
        }
    }
}
