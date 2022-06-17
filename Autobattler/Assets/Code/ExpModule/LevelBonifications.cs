using System;
using Autobattler.ExpModule.Stats;

namespace Autobattler.ExpModule
{
    [Serializable]
    public struct LevelBonifications
    {
        public StatsPackModel[] statsPacks;
        public RoundData[] mutationsPacks;
    }
}