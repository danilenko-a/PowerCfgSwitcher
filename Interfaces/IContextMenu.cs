using System;
using System.Collections.Generic;

namespace PowerCfgSwitcher.Interfaces
{
    internal interface IContextMenu
    {
        IMenuItem AddMenuItem(string name, Guid guid, Action callback, bool @checked);

        IEnumerable<IMenuItem> GetMenuItems();
    }
}
