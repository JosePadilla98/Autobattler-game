using Auttobattler.Backend.RunLogic.ManagementState;

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