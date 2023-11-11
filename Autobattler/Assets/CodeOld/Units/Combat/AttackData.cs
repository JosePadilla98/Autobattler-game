using AutobattlerOld.Units;

namespace AutobattlerOld
{
    public struct AttackData
    {
        public float percentage;
        public StatsNames statUsed;

        public AttackData(float percentage, StatsNames statScaler)
        {
            this.percentage = percentage;
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
