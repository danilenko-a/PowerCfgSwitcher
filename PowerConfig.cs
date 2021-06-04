using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerCfgSwitcher
{
    internal class PowerConfig
    {
        public ActiveState IsActive { get; set; }

        public Guid Guid { get; }

        public string Name { get; }

        public PowerConfig(Guid guid, string name, bool isActive)
        {
            Guid = guid;
            Name = name;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $"{Name} {IsActive}".Trim();
        }
    }
}
