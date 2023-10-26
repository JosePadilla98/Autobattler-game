using System;
using AutobattlerOld.Configs.Color;
using AutobattlerOld.Units;

namespace AutobattlerOld.MutationsSystem.Effects
{
    [Serializable]
    public class StatsModifier : BaseEffect
    {
        public SingleStatModifier[] modifiers;

        public override String GetDescription(int timesStacked, StatsColorsConfig colorsConfig)
        {
            string output = "";

            foreach (var modifier in modifiers)
            {
                output += modifier.GetDescription(timesStacked, colorsConfig);
            }

            return output;
        }

        public void ApplyStatsModifiers(StatsContainer statsContainer)
        {
            foreach (var modifier in modifiers)
            {
                var stat = statsContainer.GetStat(modifier.statName);
                stat.AddModifier(modifier.type, modifier.value);
            }
        }

        public void UnapplyStatsModifiers(StatsContainer statsContainer)
        {
            foreach (var modifier in modifiers)
            {
                var stat = statsContainer.GetStat(modifier.statName);
                stat.RemoveModifier(modifier.type, modifier.value);
            }
        }
    }
}