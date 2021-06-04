using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerCfgSwitcher
{
    internal class PowerCfgController
    {
        private readonly PowerSchemeManager powerSchemeManager = new PowerSchemeManager();

        public PowerCfgController()
        {
        }

        internal void CongifMenu(ContextMenu contextMenu)
        {
            this.powerSchemeManager.GetPowerConfigs().ForEach(x =>
            {
                var menuItem = contextMenu.MenuItems.Add(x.Name);
                if (x.IsActive)
                    menuItem.Checked = true;
                menuItem.Tag = x.Guid;
            });
        }

        internal void SetActive(string configGuid)
        {
            var powerConfig = this.powerSchemeManager.GetPowerConfigs()
                .FirstOrDefault(x => x.Guid.ToString() == configGuid);
            if (powerConfig == null) return;

            if (!powerConfig.IsActive)
                powerSchemeManager.SetActivePowerScheme(powerConfig.Guid);
        }

        internal void UpdateMenu(ContextMenu menuStrip)
        {
            var dict = menuStrip.MenuItems.Cast<MenuItem>()
                .Where(x => x.Tag != null)
                .ToDictionary(x => x.Tag.ToString(), x => x);

            this.powerSchemeManager.GetPowerConfigs().ForEach(x =>
            {
                var item = dict[x.Guid.ToString()];

                if (x.IsActive)
                    item.Checked = true;
                else
                    item.Checked = false;
            });
        }
    }
}
