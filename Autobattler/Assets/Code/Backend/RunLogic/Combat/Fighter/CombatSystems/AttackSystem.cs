using System;

namespace Auttobattler.Backend
{
    public class AttackSystem : CombatSystem
    {
        public AttackSystem(Fighter parent) : base(parent) { }
        public Stats Stats { get => parent.Stats; }

        public Action OnAttackCasted;
        public Action OnHitMade;

        public void LaunchSimpleAttack(AttackData attack)
        {
            float value = attack.scaleFactor * Stats.GetStatValue(attack.statScaler) * BalanceConstants.DAMAGE_MULTIPLIER;
            Fighter objetive = TargetsProcessor.GetClosestEnemy(parent.Position);
            objetive.defenseSys.BeAttacked(new DamageData(value, attack.damageType));

            OnHitMade?.Invoke();
            OnAttackCasted?.Invoke();
        }
    }

    public enum DamageType
    {
        PHYSICAL, MAGICAL
    }

    public struct AttackData
    {
        public float scaleFactor;
        public StatsNames statScaler;
        public DamageType damageType;

        public AttackData(float scaleFactor, StatsNames statScaler, DamageType damageType)
        {
            this.scaleFactor = scaleFactor;
            this.statScaler = statScaler;
            this.damageType = damageType;
        }
    }

    public struct DamageData
    {
        public float value;
        public DamageType type;

        public DamageData(float value, DamageType damageType)
        {
            this.value = value;
            type = damageType;
        }
    }
}
