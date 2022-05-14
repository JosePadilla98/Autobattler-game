using System;
using Autobattler.Units;

namespace Autobattler.MutationsSystem
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