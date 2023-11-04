using System;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units
{
    public enum StatsNames
    {
        HEALTH,
        DEFENSE,
        STRENGTH,
        ATTACK_SPEED,
        MAGIC_POWER,
        MANA_REGEN,
    }

    static class OldStatsNamesMethods
    {
        public static String GetName(this StatsNames statName)
        {
            String output = "";
            switch (statName)
            {
                case StatsNames.HEALTH:
                    output = "Health";
                    break;
                case StatsNames.DEFENSE:
                    output = "Defense";
                    break;
                case StatsNames.STRENGTH:
                    output = "Strength";
                    break;
                case StatsNames.ATTACK_SPEED:
                    output = "Attack speed";
                    break;
                case StatsNames.MAGIC_POWER:
                    output = "Magic power";
                    break;
                case StatsNames.MANA_REGEN:
                    output = "Mana regen";
                    break;
            }

            return output;
        }

        public static float GetRealValue(this StatsNames statName, float value)
        {
            return StatsTheoreticalValues.dic[statName] * value;
        }
    }
}
