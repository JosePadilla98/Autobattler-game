using System.Collections.Generic;
using System.Linq;

namespace Autobattler
{
    public class StatsContainer
    {
        public int level;
        public readonly Dictionary<StatsNames, Stat> valuePairs;

        public StatsContainer()
        {
            valuePairs = StatsInitialValues.GetInitialStats(ref level);
        }

        public Stat GetStat(StatsNames name)
        {
            valuePairs.TryGetValue(name, out Stat stat);
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
                entry => entry.Value.Get()
            );

            return newDictionary;
        }
    }
}
