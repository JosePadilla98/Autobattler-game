using System;

namespace AutobattlerOld.MutationsSystem.Effects
{
    [Serializable]
    public abstract class BaseEffect
    {
        public abstract String GetDescription(int timesStacked);
    }
}
