using System;
using System.Collections.Generic;
using System.Linq;
using Autobattler.Configs;
using Autobattler.Units.Management;

namespace Autobattler
{
    internal class StatsModificationsPack
    {
        private static int POINTS_TO_MODIFY = 20;
        private static float MAX_MOD_VALUE_PER_CHOICE = 4f;
        private static float DESIRABLE_MIN_MOD_VALUE_PER_CHOICE = 1f;

        private Random random; 

        internal StatsModificationsPack(StatsContainer statsContainer)
        {
            var baseStats = statsContainer.GetStatsWithoutPercentageModifiers();
            random = new Random();
        }
    }
}