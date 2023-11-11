using AutobattlerOld.Units;

namespace AutobattlerOld.Configs.Balance
{
    public class BalanceConstants
    {
        public const float DAMAGE_MULTIPLIER = 1f;
        public const float STATS_MODS_VALUE_VARIATION_PER_ROUND = 0f;

        public static readonly StatsNames[] UNMODIFIABLE_STAT_IN_STATS_MOD = new[]
        {
            StatsNames.MANA_REGEN,
            StatsNames.ATTACK_SPEED,
        };
    }
}
