using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCfgSwitcher.Interfaces
{
    internal interface INotifyIcon : IDisposable
    {
        System.Drawing.Icon Icon { set; }

        string Text { set; }

        bool Visible { set; }

        IContextMenu ContextMenu { set; }
    }
}
