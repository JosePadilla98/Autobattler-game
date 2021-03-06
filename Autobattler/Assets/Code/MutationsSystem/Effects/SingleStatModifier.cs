using System;
using Autobattler.Configs;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.MutationsSystem
{
    [Serializable]
    public class SingleStatModifier 
    {
        public StatsNames statName;
        public ModifierType type;
        public float value;

        public String GetDescription(int timesStacked, StatsColorsConfig colorsConfig)
        {
            String outPut = "";
            if (value > 0)
            {
                outPut += "+";
            }
            else if(value < 0)
            {
                outPut += "-";
            }
            else
            {
                throw new Exception("This has no sense");
            }

            outPut += (value * timesStacked).ToString();
            if(type == ModifierType.PERCENTAGE)
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