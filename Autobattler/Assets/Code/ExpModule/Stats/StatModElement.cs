using Autobattler.Units;

namespace Autobattler.ExpModule.Stats
{
    public struct StatModElement
    {
        public StatsNames statToAdd;
        public StatsNames statToSubstract;
        public float value;

        public StatModElement(StatsNames statToAdd, StatsNames statToSubstract, float value)
        {
            this.statToAdd = statToAdd;
            this.statToSubstract = statToSubstract;
            this.value = value;
        }
    }
}