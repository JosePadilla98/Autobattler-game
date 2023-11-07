using System.Collections.Generic;
using System.Linq;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units
{
    public class StatsContainer
    {
        public readonly Dictionary<StatsNames, Stat> valuePairs;

        public StatsContainer()
        {
            valuePairs = StatsInitialValues.GetInitialStats();
        }

        public Stat GetStat(StatsNames name)
        {
            Stat stat;
            valuePairs.TryGetValue(name, out stat);
            return stat;
        }

        public float GetStatValue(StatsNames name)
        {
            var stat = GetStat(name);
            return stat.Get();
        }

        public Dictionary<StatsNames, float> GetStatsWithoutPercentageModifiers()
        {
            var newDictionary = valuePairs.ToDictionary(
                entry => entry.Key,
                entry => entry.Value.GetOnlyWithLinearModifiers()
            );

            return newDictionary;
        }
    }
}
