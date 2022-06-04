using System.Collections.Generic;
using Autobattler.MutationsSystem;

namespace Autobattler.Units.Management
{
    public class StatsContainer
    {
        public int level;
        private readonly Dictionary<StatsNames, Stat> valuePairs;

        public StatsContainer()
        {
            level = 1;
            valuePairs = StandardStats();
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

        private Dictionary<StatsNames, Stat> StandardStats()
        {
            var dic = new Dictionary<StatsNames, Stat>
            {
                { StatsNames.HEALTH, new Stat(25f) },
                { StatsNames.HEALTH_REGEN, new Stat(1f) },

                { StatsNames.PHYSICAL_ATTACK, new Stat(25f, ref level) },
                { StatsNames.MAGICAL_ATTACK, new Stat(25f, ref level) },

                { StatsNames.PHYSICAL_DEFENSE, new Stat(25f, ref level) },
                { StatsNames.MAGICAL_DEFENSE, new Stat(25f, ref level) },

                { StatsNames.PHYSICAL_SPEED, new Stat(25f) },
                { StatsNames.MAGICAL_SPEED, new Stat(25f) },

                { StatsNames.VIGOR, new Stat(25f) },
                { StatsNames.REINVIGORATION, new Stat(1f) },

                { StatsNames.MANA, new Stat(25f) },
                { StatsNames.MANA_REGEN, new Stat(1f) },

                { StatsNames.INTELLECT, new Stat(25f) },

                { StatsNames.WEIGHT_CAPACITY, new Stat(1f) },

                { StatsNames.PHYSICAL_FATIGUE, new Stat(1f) },
                { StatsNames.MAGICAL_FATIGUE, new Stat(1f) }
            };

            return dic;
        }

       
    }
}