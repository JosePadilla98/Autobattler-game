using AutobattlerOld.Units;

namespace AutobattlerOld
{
    public struct AttackData
    {
        public float power;
        public StatsNames statUsed;

        public AttackData(float scaleFactor, StatsNames statScaler)
        {
            this.power = scaleFactor;
            this.statUsed = statScaler;
        }
    }

    public struct DamageData
    {
        public float value;

        public DamageData(float value)
        {
            this.value = value;
        }
    }
}
