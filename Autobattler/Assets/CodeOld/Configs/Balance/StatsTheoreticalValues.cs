using System.Collections.Generic;
using AutobattlerOld.Units;

namespace AutobattlerOld.Configs.Balance
{
    public static class StatsTheoreticalValues
    {
        public static Dictionary<OldStatsNames, float> dic { get; } =
            new Dictionary<OldStatsNames, float>()
            {
                { OldStatsNames.HEALTH, 1 },
                { OldStatsNames.HEALTH_REGEN, 0.1f },
                { OldStatsNames.PHYSICAL_ATTACK, 1 },
                { OldStatsNames.MAGICAL_ATTACK, 1 },
                { OldStatsNames.PHYSICAL_DEFENSE, 1 },
                { OldStatsNames.MAGICAL_DEFENSE, 1 },
                { OldStatsNames.PHYSICAL_SPEED, 1 },
                { OldStatsNames.MAGICAL_SPEED, 1 },
                { OldStatsNames.VIGOR, 1 },
                { OldStatsNames.REINVIGORATION, 0.1f },
                { OldStatsNames.MANA, 1 },
                { OldStatsNames.MANA_REGEN, 0.1f },
                { OldStatsNames.INTELLECT, 1 },
            };
    }
}
