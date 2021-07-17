using System;
using System.Collections.Generic;

namespace PowerCfgSwitcher.Interfaces
{
    internal interface IContextMenu
    {
        IMenuItem AddMenuItem(string name, Guid guid, Action callback, bool @checked);

        IMenuItem AddMenuItem(string name, EventHandler click);

        void AddClickHandler(EventHandler click);

        IEnumerable<IMenuItem> GetMenuItems();

        event EventHandler Popup;
    }
}
