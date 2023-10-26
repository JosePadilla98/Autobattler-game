using System;
using AutobattlerOld.ExpModule.Stats;

namespace AutobattlerOld.ExpModule
{
    [Serializable]
    public struct LevelBonifications
    {
        public StatsPackModel[] statsPacks;
        public RoundData[] mutationsPacks;
    }
}