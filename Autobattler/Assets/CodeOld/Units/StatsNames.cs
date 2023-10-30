using System;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units
{
    ///
    /// Regenerations represents "regenerations" each 4 seconds
    /// 

    public enum OldStatsNames
    {
        HEALTH,
        HEALTH_REGEN,
        PHYSICAL_ATTACK,
        MAGICAL_ATTACK,
        PHYSICAL_DEFENSE,
        MAGICAL_DEFENSE,
        PHYSICAL_SPEED,
        MAGICAL_SPEED,
        VIGOR,
        REINVIGORATION,
        MANA,
        MANA_REGEN,
        INTELLECT,

        WEIGHT_CAPACITY,

        PHYSICAL_FATIGUE,
        MAGICAL_FATIGUE
    }


    static class OldStatsNamesMethods
    {
        public static String GetName(this OldStatsNames statName)
        {
            String output = "";
            switch (statName)
            {
                case OldStatsNames.HEALTH:
                    output = "Health";
                    break;
                case OldStatsNames.HEALTH_REGEN:
                    output = "Health regeneration";
                    break;
                case OldStatsNames.PHYSICAL_ATTACK:
                    output = "Physical attack";
                    break;
                case OldStatsNames.MAGICAL_ATTACK:
                    output = "Magical attack";
                    break;
                case OldStatsNames.PHYSICAL_DEFENSE:
                    output = "Physical defense";
                    break;
                case OldStatsNames.MAGICAL_DEFENSE:
                    output = "Magical defense";
                    break;
                case OldStatsNames.PHYSICAL_SPEED:
                    output = "Physical speed";
                    break;
                case OldStatsNames.MAGICAL_SPEED:
                    output = "Magical speed";
                    break;
                case OldStatsNames.VIGOR:
                    output = "Vigor";
                    break;
                case OldStatsNames.REINVIGORATION:
                    output = "Reinvigoration";
                    break;
                case OldStatsNames.MANA:
                    output = "Mana";
                    break;
                case OldStatsNames.MANA_REGEN:
                    output = "Mana regen";
                    break;
                case OldStatsNames.INTELLECT:
                    output = "Intellect";
                    break;
                case OldStatsNames.WEIGHT_CAPACITY:
                    output = "Weight capacity";
                    break;
                case OldStatsNames.PHYSICAL_FATIGUE:
                    output = "Physical fatigue";
                    break;
                case OldStatsNames.MAGICAL_FATIGUE:
                    output = "Magical fatigue";
                    break;
            }

            return output;
        }

        public static float GetRealValue(this OldStatsNames statName, float value)
        {
            return StatsTheoreticalValues.dic[statName] * value;
        }
    }
}

