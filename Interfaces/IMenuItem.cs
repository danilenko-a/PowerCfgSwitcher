using System;

namespace PowerCfgSwitcher.Interfaces
{
    public interface IMenuItem
    {
        Action Callback { get; set; }

        bool Checked { get; set; }

        Guid Guid { get; }
    }
}