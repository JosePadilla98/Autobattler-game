using System.Collections.Generic;
using System.Linq;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units
{
    public class StatsContainer
    {
        public int level;
        public readonly Dictionary<OldStatsNames, Stat> valuePairs;

        public StatsContainer(int initialLevel)
        {
            level = initialLevel;
            valuePairs = StatsInitialValues.GetInitialStats(ref level);
        }

        public Stat GetStat(OldStatsNames name)
        {
            Stat stat;
            valuePairs.TryGetValue(name, out stat);
            return stat;
        }

        public float GetStatValue(OldStatsNames name)
        {
            var stat = GetStat(name);
            return stat.Get();
        }

        public Dictionary<OldStatsNames, float> GetStatsWithoutPercentageModifiers()
        {
            var newDictionary = valuePairs.ToDictionary(
                entry => entry.Key,
                entry => entry.Value.GetOnlyWithLinearModifiers()
            );

            return newDictionary;
        }
    }
}
