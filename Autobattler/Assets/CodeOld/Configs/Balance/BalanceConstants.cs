using AutobattlerOld.Units;

namespace AutobattlerOld.Configs.Balance
{
    public class BalanceConstants
    {
        public const float LEVEL_STATS_INCREMENT_FACTOR = 0.1f;
        public const float DAMAGE_MULTIPLIER = 1f;
        public const float STATS_MODS_VALUE_VARIATION_PER_ROUND = 0f;

        public static readonly OldStatsNames[] UNMODIFIABLE_STAT_IN_STATS_MOD = new[]
        {
            OldStatsNames.MAGICAL_FATIGUE,
            OldStatsNames.PHYSICAL_FATIGUE,
            OldStatsNames.WEIGHT_CAPACITY
        };
    }
}
