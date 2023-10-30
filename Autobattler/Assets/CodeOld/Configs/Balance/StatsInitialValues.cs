using System.Collections.Generic;
using AutobattlerOld.Units;

namespace AutobattlerOld.Configs.Balance
{
    public class StatsInitialValues
    {
        public static Dictionary<OldStatsNames, float> InitialValues { get; } =
            new Dictionary<OldStatsNames, float>()
            {
                { OldStatsNames.HEALTH, 10 },
                { OldStatsNames.HEALTH_REGEN, 0.25f },
                { OldStatsNames.PHYSICAL_ATTACK, 10 },
                { OldStatsNames.MAGICAL_ATTACK, 10 },
                { OldStatsNames.PHYSICAL_DEFENSE, 10 },
                { OldStatsNames.MAGICAL_DEFENSE, 10 },
                { OldStatsNames.PHYSICAL_SPEED, 10 },
                { OldStatsNames.MAGICAL_SPEED, 10 },
                { OldStatsNames.VIGOR, 10 },
                { OldStatsNames.REINVIGORATION, 0.25f },
                { OldStatsNames.MANA, 10 },
                { OldStatsNames.MANA_REGEN, 0.25f },
                { OldStatsNames.INTELLECT, 10 },
                { OldStatsNames.WEIGHT_CAPACITY, 10 },
                { OldStatsNames.PHYSICAL_FATIGUE, 1 },
                { OldStatsNames.MAGICAL_FATIGUE, 1 },
            };

        public static Dictionary<OldStatsNames, Stat> GetInitialStats(ref int level)
        {
            var dic = new Dictionary<OldStatsNames, Stat>();
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
