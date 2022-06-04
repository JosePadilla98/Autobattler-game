using System;
using Autobattler.Configs;

namespace Autobattler.MutationsSystem
{
    [Serializable]
    public abstract class BaseEffect
    {
        public abstract String GetDescription(int timesStacked, StatsColorsConfig colorsConfig);

    }
}