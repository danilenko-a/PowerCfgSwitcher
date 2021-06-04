using System.Linq;
using PowerCfgSwitcher.Interfaces;

namespace PowerCfgSwitcher
{
    internal class ContextMenuController : IContextMenuController
    {
        private readonly PowerSchemeManager powerSchemeManager = new PowerSchemeManager();

        public ContextMenuController()
        {
        }

        public void CongifMenu(IContextMenu contextMenu)
        {
            this.powerSchemeManager.GetPowerConfigs().ForEach(x =>
            {
                var menuItem = contextMenu.AddMenuItem(x.Name, x.Guid, () => SetActive(x), x.IsActive);
            });
        }

        public void UpdateMenu(IContextMenu contextMenu)
        {
            var dict = contextMenu.GetMenuItems()
                .ToDictionary(x => x.Guid, x => x);

            this.powerSchemeManager.GetPowerConfigs().ForEach(x =>
            {
                if (dict.ContainsKey(x.Guid))
                {
                    var menuItem = dict[x.Guid];
                    menuItem.Callback = () => SetActive(x);

                    if (x.IsActive)
                        menuItem.Checked = true;
                    else
                        menuItem.Checked = false;
                }
            });
        }

        private void SetActive(PowerConfig powerConfig)
        {
            if (powerConfig == null) return;

            if (!powerConfig.IsActive)
                powerSchemeManager.SetActivePowerScheme(powerConfig.Guid);
        }


    }
}
