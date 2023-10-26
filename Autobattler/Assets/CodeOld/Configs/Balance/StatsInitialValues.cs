using System.Collections.Generic;
using AutobattlerOld.Units;

namespace AutobattlerOld.Configs.Balance
{
    public class StatsInitialValues
    {
        public static Dictionary<StatsNames, float> InitialValues { get; } = new Dictionary<StatsNames, float>()
        {
            { StatsNames.HEALTH, 10 },
            { StatsNames.HEALTH_REGEN, 0.25f },

            { StatsNames.PHYSICAL_ATTACK, 10 },
            { StatsNames.MAGICAL_ATTACK, 10 },

            { StatsNames.PHYSICAL_DEFENSE, 10 },
            { StatsNames.MAGICAL_DEFENSE, 10 },

            { StatsNames.PHYSICAL_SPEED, 10 },
            { StatsNames.MAGICAL_SPEED, 10 },

            { StatsNames.VIGOR, 10 },
            { StatsNames.REINVIGORATION, 0.25f },

            { StatsNames.MANA, 10 },
            { StatsNames.MANA_REGEN, 0.25f },

            { StatsNames.INTELLECT, 10 },

            { StatsNames.WEIGHT_CAPACITY, 10 },

            { StatsNames.PHYSICAL_FATIGUE, 1 },
            { StatsNames.MAGICAL_FATIGUE, 1 },
        };

        public static Dictionary<StatsNames, Stat> GetInitialStats(ref int level)
        {
            var dic = new Dictionary<StatsNames, Stat>();
            foreach (var keyValue in InitialValues)
            {
                if (Stat.CheckIfScalesByLevel(keyValue.Key))
                {
                    dic.Add(keyValue.Key, new Stat(keyValue.Value, ref level));
                }
                else
                {
                    dic.Add(keyValue.Key, new Stat(keyValue.Value));
                }
            }

            return dic;
        }
    }
}