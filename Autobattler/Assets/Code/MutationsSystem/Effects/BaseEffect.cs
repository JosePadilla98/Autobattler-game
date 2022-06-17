using System;
using Autobattler.Configs.Color;

namespace Autobattler.MutationsSystem.Effects
{
    [Serializable]
    public abstract class BaseEffect
    {
        public abstract String GetDescription(int timesStacked, StatsColorsConfig colorsConfig);

    }
}