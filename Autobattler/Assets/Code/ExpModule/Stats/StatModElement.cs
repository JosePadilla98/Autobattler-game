using Autobattler.Units;
using UnityEngine.UIElements;

namespace Autobattler.ExpModule.Stats
{
    public struct StatModElement
    {
        public StatsNames statToAdd;
        public StatsNames statToSubstract;
        public float ModValue;

        public StatModElement(StatsNames statToAdd, StatsNames statToSubstract, float modValue)
        {
            this.statToAdd = statToAdd;
            this.statToSubstract = statToSubstract;
            this.ModValue = modValue;
        }
    }
}