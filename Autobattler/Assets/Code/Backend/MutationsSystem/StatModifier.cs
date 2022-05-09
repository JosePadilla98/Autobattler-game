using Auttobattler.Backend.RunLogic.Management;

namespace Auttobattler.MutationsSystem
{
    [System.Serializable]
    public class StatModifier
    {
        public StatsNames statName;
        public ModifierType type;
        public float value;
    }

    public enum ModifierType
    {
        LINEAL, PERCENTAGE
    }
}