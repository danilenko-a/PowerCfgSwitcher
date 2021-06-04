using System;

namespace PowerCfgSwitcher
{
    internal class PowerConfig : IEquatable<PowerConfig>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as PowerConfig);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} {IsActive}".Trim();
        }

        public bool Equals(PowerConfig other)
        {
            return this.Guid.Equals(other.Guid);
        }
    }
}
