using System;
using AutobattlerOld.Configs.Color;
using AutobattlerOld.Units;

namespace AutobattlerOld.MutationsSystem.Effects
{
    [Serializable]
    public class SingleStatModifier
    {
        public OldStatsNames statName;
        public ModifierType type;
        public float value;

        public String GetDescription(int timesStacked, StatsColorsConfig colorsConfig)
        {
            String outPut = "";
            if (value > 0)
            {
                outPut += "+";
            }
            else if (value < 0)
            {
                outPut += "-";
            }
            else
            {
                throw new Exception("This has no sense");
            }

            outPut += (value * timesStacked).ToString();
            if (type == ModifierType.PERCENTAGE)
                outPut += "%";

            outPut += " " + statName;
            return outPut;
        }
    }

    public enum ModifierType
    {
        LINEAL,
        PERCENTAGE
    }
}
