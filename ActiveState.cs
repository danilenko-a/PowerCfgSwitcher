namespace PowerCfgSwitcher
{
    public class ActiveState
    {
        private readonly bool value;

        public ActiveState(bool value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value ? "(Активно)" : "";
        }

        public static implicit operator bool(ActiveState activeState) => activeState.value;

        public static implicit operator ActiveState(bool value) => new ActiveState(value);
    }
}