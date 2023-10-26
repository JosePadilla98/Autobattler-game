using System;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units
{
    ///
    /// Regenerations represents "regenerations" each 4 seconds
    /// 

    public enum StatsNames
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


    static class StatsNamesMethods
    {
        public static String GetName(this StatsNames statName)
        {
            String output = "";
            switch (statName)
            {
                case StatsNames.HEALTH:
                    output = "Health";
                    break;
                case StatsNames.HEALTH_REGEN:
                    output = "Health regeneration";
                    break;
                case StatsNames.PHYSICAL_ATTACK:
                    output = "Physical attack";
                    break;
                case StatsNames.MAGICAL_ATTACK:
                    output = "Magical attack";
                    break;
                case StatsNames.PHYSICAL_DEFENSE:
                    output = "Physical defense";
                    break;
                case StatsNames.MAGICAL_DEFENSE:
                    output = "Magical defense";
                    break;
                case StatsNames.PHYSICAL_SPEED:
                    output = "Physical speed";
                    break;
                case StatsNames.MAGICAL_SPEED:
                    output = "Magical speed";
                    break;
                case StatsNames.VIGOR:
                    output = "Vigor";
                    break;
                case StatsNames.REINVIGORATION:
                    output = "Reinvigoration";
                    break;
                case StatsNames.MANA:
                    output = "Mana";
                    break;
                case StatsNames.MANA_REGEN:
                    output = "Mana regen";
                    break;
                case StatsNames.INTELLECT:
                    output = "Intellect";
                    break;
                case StatsNames.WEIGHT_CAPACITY:
                    output = "Weight capacity";
                    break;
                case StatsNames.PHYSICAL_FATIGUE:
                    output = "Physical fatigue";
                    break;
                case StatsNames.MAGICAL_FATIGUE:
                    output = "Magical fatigue";
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

