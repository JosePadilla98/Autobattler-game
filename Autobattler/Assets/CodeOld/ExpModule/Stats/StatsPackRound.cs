using System;
using System.Collections.Generic;
using System.Linq;
using AutobattlerOld.Configs.Balance;
using AutobattlerOld.UnitLevellingScreens;
using AutobattlerOld.Units;
using Random = System.Random;

namespace AutobattlerOld.ExpModule.Stats
{
    [Serializable]
    public struct RoundData
    {
        public int elementsNum;
        public int choicesNum;
    }

    public class StatsPackRound
    {
        private Random Random => RandomController.Random;

        public List<StatModElement> elements = new List<StatModElement>();
        public Action onRoundConsumed;

        private Dictionary<StatsNames, float> statsYouCanSubstractFrom;
        private Dictionary<StatsNames, float> baseStats;

        private float roundValue;
        public float RoundValue => roundValue;
        private StatsContainer statsContainer;

        public StatsPackRound(
            Action onRoundConsumed,
            StatsContainer statsContainer,
            RoundData roundData,
            float orientativeRoundValue,
            bool applyValueVariation = true
        )
        {
            roundValue = orientativeRoundValue;
            this.statsContainer = statsContainer;
            this.onRoundConsumed = onRoundConsumed;

            if (applyValueVariation)
            {
                var variation = BalanceConstants.STATS_MODS_VALUE_VARIATION_PER_ROUND;
                roundValue *= GetRandomFloat(1 + variation, 1 - variation);
            }

            baseStats = GetModificableBaseStats(statsContainer);
            statsYouCanSubstractFrom = GetStatsYouCanSubstractFrom(statsContainer);

            for (int i = 0; i < roundData.elementsNum; i++)
            {
                elements.Add(GetElement(ref roundValue));
            }

            //Equals the value of all the elements to the minimum value of all of them
            for (int i = roundData.elementsNum - 1; i >= 0; i--)
            {
                var copy = elements[i];
                copy.ModValue = roundValue;
                elements[i] = copy;
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

        private Dictionary<StatsNames, float> GetStatsYouCanSubstractFrom(
            StatsContainer statsContainer
        )
        {
            var statsYouCanModify = GetModificableBaseStats(statsContainer);

            var itemsToRemove = statsYouCanModify.Where(kvp => !(kvp.Value > 0)).ToArray();
            foreach (var kvp in itemsToRemove)
            {
                statsYouCanModify.Remove(kvp.Key);
            }

            return statsYouCanModify;
        }

        private StatModElement GetElement(ref float modValue)
        {
            KeyValuePair<StatsNames, float> statToSubstractPoints = SelectRandomStat(
                statsYouCanSubstractFrom
            );
            // No other element will have the same stat in the subtractive part:
            statsYouCanSubstractFrom.Remove(statToSubstractPoints.Key);

            //The stat to be added cannot be the same as the one removed #1
            StatsNames statToBeRemoved = statToSubstractPoints.Key;
            KeyValuePair<StatsNames, float> tmpStatContainer =
                new(statToBeRemoved, baseStats[statToBeRemoved]);
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
            output.ModValue = modValue;

            return output;
        }

        private KeyValuePair<StatsNames, float> SelectRandomStat(
            Dictionary<StatsNames, float> statsToChoose
        )
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
            return (float)(RandomController.Random.NextDouble() * (max - min) + min);
        }

        public void SaveSelection(IEnumerable<StatModView> modViews)
        {
            if (modViews != null)
            {
                foreach (var modView in modViews)
                {
                    modView.Element.Apply(statsContainer);
                }
            }

            onRoundConsumed?.Invoke();
            onRoundConsumed = null;
        }
    }
}
