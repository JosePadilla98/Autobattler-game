using System.Collections.Generic;
using AutobattlerOld.Units;

namespace AutobattlerOld.Configs.Balance
{
    public static class StatsTheoreticalValues
    {
        public static Dictionary<StatsNames, float> dic { get; } =
            new Dictionary<StatsNames, float>()
            {
                { StatsNames.HEALTH, 1 },
                { StatsNames.DEFENSE, 1f },
                { StatsNames.STRENGTH, 1f },
                { StatsNames.MAGIC_POWER, 1f },
                { StatsNames.ATTACK_SPEED, 0.025f },
                { StatsNames.MANA_REGEN, 0.01f },
            };
    }
}
