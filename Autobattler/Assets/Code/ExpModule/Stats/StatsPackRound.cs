using System;
using System.Collections.Generic;
using System.Linq;
using Autobattler.Configs.Balance;
using Autobattler.Units;

namespace Autobattler.ExpModule.Stats
{
    [Serializable]
    public struct RoundData
    {
        public int elementsNum;
        public int choicesNum;
    }

    public class StatsPackRound
    {
        private Random Random => RandomController.random;

        public List<StatModElement> elements = new List<StatModElement>();
        public Action onRoundConsumed;

        private Dictionary<StatsNames, float> statsYouCanSubstractFrom;
        private Dictionary<StatsNames, float> baseStats;

        private float modValue;

        public StatsPackRound(Action onRoundConsumed, StatsContainer statsContainer, RoundData roundData, float orientativeModValue, bool applyValueVariation = true)
        {
            modValue = orientativeModValue;

            if (applyValueVariation)
            {
                var variation = BalanceConstants.STATS_MODS_VALUE_VARIATION_PER_ROUND;
                modValue *= GetRandomFloat(variation, -variation);
            }

            baseStats = GetModificableBaseStats(statsContainer);
            statsYouCanSubstractFrom = GetStatsYouCanSubstractFrom(statsContainer);

            for (int i = 0; i < roundData.elementsNum; i++)
            {
                elements.Add(GetElement(ref modValue));
            }
        }

        private Dictionary<StatsNames, float> GetModificableBaseStats(StatsContainer statsContainer)
        {
            var statsYouCanModify = statsContainer.GetStatsWithoutPercentageModifiers();

            foreach (var stat in BalanceConstants.UNMODIFIABLE_STAT_IN_STATS_MOD)
            {
                statsYouCanModify.Remove(stat);
            }

            return statsYouCanModify;
        }

        private Dictionary<StatsNames, float> GetStatsYouCanSubstractFrom(StatsContainer statsContainer)
        {
            var statsYouCanModify = GetModificableBaseStats(statsContainer);

            var itemsToRemove = statsYouCanModify.Where(kvp => !(kvp.Value > 0 )).ToArray();
            foreach (var kvp in itemsToRemove)
            {
                statsYouCanModify.Remove(kvp.Key);
            }

            return statsYouCanModify;
        }

        private StatModElement GetElement(ref float modValue)
        {
            KeyValuePair<StatsNames, float> statToSubstractPoints = SelectRandomStat(statsYouCanSubstractFrom);
            // No other element will have the same stat in the subtractive part:
            statsYouCanSubstractFrom.Remove(statToSubstractPoints.Key);

            //The stat to be added cannot be the same as the one removed #1 
            StatsNames statToBeRemoved = statToSubstractPoints.Key;
            KeyValuePair<StatsNames, float> tmpStatContainer = new(statToBeRemoved, baseStats[statToBeRemoved]);
            baseStats.Remove(statToSubstractPoints.Key);

            KeyValuePair<StatsNames, float> statToAddPoints = SelectRandomStat(baseStats);

            //The stat to be added cannot be the same as the one removed #2
            baseStats.Add(tmpStatContainer.Key, tmpStatContainer.Value);

            var maxValueYouCanSubstract = CalculateMaxValueYouCanSubstract(statToSubstractPoints);
            if (modValue > maxValueYouCanSubstract)
            {
                modValue = maxValueYouCanSubstract;
            }

            var output = new StatModElement();
            output.statToAdd = statToAddPoints.Key;
            output.statToSubstract = statToSubstractPoints.Key;
            output.value = modValue;

            return output;
        }

        private KeyValuePair<StatsNames, float> SelectRandomStat(Dictionary<StatsNames, float> statsToChoose)
        {
            int randomIndex = Random.Next(statsToChoose.Count);
            var pair = statsToChoose.ElementAt(randomIndex);
            return pair;
        }

        private float CalculateMaxValueYouCanSubstract(KeyValuePair<StatsNames, float> stat)
        {
            var statTheoricValue = StatsTheoreticalValues.dic[stat.Key];
            return stat.Value / statTheoricValue;
        }

        private float GetRandomFloat(float max, float min)
        {
            return (float)(RandomController.random.NextDouble() * (max - min) + min);
        }
    }
}