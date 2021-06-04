using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerCfgSwitcher
{
    internal class PowerSchemeManager
    {
        private readonly PowerprofWrapper powerprofWrapper = new PowerprofWrapper();

        public PowerSchemeManager()
        { }

        public IEnumerable<PowerConfig> GetPowerConfigs()
        {
            var activeGuid = powerprofWrapper.GetActivePowerSchemeGuid();

            foreach (var guid in powerprofWrapper.GetAllPowerSchemeGuids())
            {
                bool isActive = activeGuid.Equals(guid);
                string name = powerprofWrapper.GetPowerSchemeName(guid);
                yield return new PowerConfig(guid, name, isActive);
            }
        }

        public void SetActivePowerScheme(Guid guid)
        {
            powerprofWrapper.SetActivePowerScheme(guid);
        }
    }
}
