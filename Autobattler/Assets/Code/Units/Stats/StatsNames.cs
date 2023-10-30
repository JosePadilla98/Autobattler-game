using System;

namespace Autobattler
{
    public enum StatsNames
    {
        HEALTH,
        DEFENSE,
        STRENGTH,
        ATTACK_SPEED,
        MAGICAL_POWER,
        MANA_REGEN,
    }

    static class StatsNamesMethods
    {
        public static string GetName(StatsNames statName)
        {
            string output = "";
            switch (statName)
            {
                case StatsNames.HEALTH:
                    output = "Health";
                    break;
            }

            return output;
        }
    }
}
