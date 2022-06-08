using System.Collections.Generic;
using Autobattler.Units.Management;

namespace Autobattler.Configs
{
    public static class StatsTheoreticalValues
    {
        public static Dictionary<StatsNames, float> dic { get; } = new Dictionary<StatsNames, float>()
        {
            { StatsNames.HEALTH, 1 },
            { StatsNames.HEALTH_REGEN, 0.1f },

            { StatsNames.PHYSICAL_ATTACK, 1 },
            { StatsNames.MAGICAL_ATTACK, 1 },

            { StatsNames.PHYSICAL_DEFENSE, 1 },
            { StatsNames.MAGICAL_DEFENSE, 1 },

            { StatsNames.PHYSICAL_SPEED, 1 },
            { StatsNames.MAGICAL_SPEED, 1 },

            { StatsNames.VIGOR, 1 },
            { StatsNames.REINVIGORATION, 0.1f },

            { StatsNames.MANA, 1 },
            { StatsNames.MANA_REGEN, 0.1f },

            { StatsNames.INTELLECT, 1 },
        };
    }
}