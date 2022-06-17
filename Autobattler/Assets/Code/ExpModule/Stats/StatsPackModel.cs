using System;

namespace Autobattler.ExpModule.Stats
{
    [Serializable]
    public struct StatsPackModel
    {
        public float totalValueToModify;
        public RoundData roundData;
        public int desirableNumOfRounds;
    }
}