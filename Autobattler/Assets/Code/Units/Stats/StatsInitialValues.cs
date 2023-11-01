using System.Collections.Generic;

namespace Autobattler
{
    public class StatsInitialValues
    {
        public static Dictionary<StatsNames, float> InitialValues { get; } =
            new Dictionary<StatsNames, float>()
            {
                { StatsNames.HEALTH, 10f },
                { StatsNames.DEFENSE, 10f },
                { StatsNames.STRENGTH, 10f },
                { StatsNames.ATTACK_SPEED, 0.25f },
                { StatsNames.MAGIC_POWER, 10f },
                { StatsNames.MANA_REGEN, 1f },
            };

        public static Dictionary<StatsNames, Stat> GetInitialStats(ref int level)
        {
            var dic = new Dictionary<StatsNames, Stat>();
            foreach (var keyValue in InitialValues)
            {
                dic.Add(keyValue.Key, new Stat(keyValue.Value));
            }

            return dic;
        }
    }
}
