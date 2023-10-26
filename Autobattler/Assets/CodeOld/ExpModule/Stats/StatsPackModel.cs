using System;

namespace AutobattlerOld.ExpModule.Stats
{
    [Serializable]
    public struct StatsPackModel
    {
        public float totalValueToModify;
        public RoundData roundData;
        public int desirableNumOfRounds;
    }
}