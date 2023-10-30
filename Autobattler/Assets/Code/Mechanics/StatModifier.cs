using System;

namespace Autobattler
{
    [Serializable]
    public class StatModifier
    {
        public StatsNames statName;
        public ModifierType type;
        public float value;
    }

    public enum ModifierType
    {
        LINEAL,
        PERCENTAGE
    }
}
