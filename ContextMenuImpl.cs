using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PowerCfgSwitcher.Interfaces;

namespace PowerCfgSwitcher
{
    internal class ContextMenuImpl : ContextMenu, IContextMenu
    {
        public ContextMenuImpl()
        { }

        public IMenuItem AddMenuItem(string name, Guid guid, Action callback, bool @checked)
        {
            var menuItem = this.MenuItems.Add(name);
            menuItem.Tag = new { guid, callback };
            menuItem.Checked = @checked;

            return new MenuItemImpl(menuItem);
        }

        public IEnumerable<IMenuItem> GetMenuItems()
        {
            return this.MenuItems.Cast<MenuItem>()
                .Where(x => x.Tag != null)
                .Select(x => new MenuItemImpl(x));
        }
    }
}
