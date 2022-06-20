using Autobattler.Units;

namespace Autobattler.Configs.Balance
{
    public class BalanceConstants
    {
        public const float LEVEL_STATS_INCREMENT_FACTOR = 0.1f;
        public const float DAMAGE_MULTIPLIER = 1f;
        public const float STATS_MODS_VALUE_VARIATION_PER_ROUND = 0f;

        public static readonly StatsNames[] UNMODIFIABLE_STAT_IN_STATS_MOD = new []
        {
            StatsNames.MAGICAL_FATIGUE,
            StatsNames.PHYSICAL_FATIGUE,
            StatsNames.WEIGHT_CAPACITY
        };
    }
}