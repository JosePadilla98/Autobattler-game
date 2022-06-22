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

        public void Apply(StatsContainer statsContainer)
        {
            statsContainer.GetStat(statToAdd).baseStat += GetAdditionValue();
            statsContainer.GetStat(statToSubstract).baseStat += GetSubstractionValue();
        }

        public float GetAdditionValue()
        {
            return statToAdd.GetRealValue(ModValue);
        }

        public float GetSubstractionValue()
        {
            return statToSubstract.GetRealValue(ModValue);
        }
    }
}