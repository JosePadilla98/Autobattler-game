using System;
using System.Collections.Generic;
using System.Linq;
using Autobattler.Configs;
using Autobattler.Units.Management;

namespace Autobattler
{
    public class StatsModifications_Row
    {
        private readonly Random random;

        public static void CreateRow()
        {



        }

        private float GetRandomModValue(float max, float min)
        {
            return (float)(random.NextDouble() * (max - min) + min);
        }

        private void GetChoice(Dictionary<StatsNames, float> baseStats, Random random)
        {
            KeyValuePair<StatsNames, float> statToSubstractPoints = SelectRandomStat(baseStats, random);
            Dictionary<StatsNames, float> possibleStatsToAddPoints = SubstractStatAndGetCopy(baseStats, statToSubstractPoints.Key);
            KeyValuePair<StatsNames, float> statToAddPoints = SelectRandomStat(possibleStatsToAddPoints, random);

            //CalculateMaxValueYouCanSubstract
        }

        /// <summary>
        /// Used to not add points to the same stat you are subtracting from
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="statToSubstract"></param>
        /// <returns></returns>
        private Dictionary<StatsNames, float> SubstractStatAndGetCopy(Dictionary<StatsNames, float> dictionary, StatsNames statToSubstract)
        {
            var copy = dictionary.ToDictionary(
                entry => entry.Key,
                entry => entry.Value);

            copy.Remove(statToSubstract);
            return copy;
        }

        private KeyValuePair<StatsNames, float> SelectRandomStat(Dictionary<StatsNames, float> statsToChoose, Random random)
        {
            int randomIndex = random.Next(statsToChoose.Count);
            var pair = statsToChoose.ElementAt(randomIndex);
            return pair;
        }

        private float CalculateMaxValueYouCanSubstract(KeyValuePair<StatsNames, float> stat)
        {
            var statTheoricValue = StatsTheoreticalValues.dic[stat.Key];
            return stat.Value / statTheoricValue;
        }
    }
}