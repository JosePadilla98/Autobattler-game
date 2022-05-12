using System;
using Autobattler.Configs;
using Autobattler.Unit.Unit;

namespace Autobattler.Unit.Fighter.CombatSystems
{
    public class AttackSystem : CombatSystem
    {
        public Action OnAttackCasted;
        public Action OnHitMade;

        public AttackSystem(Fighter parent) : base(parent)
        {
        }

        public Stats Stats => parent.Stats;

        public void LaunchSimpleAttack(AttackData attack)
        {
            var value = attack.scaleFactor * Stats.GetStatValue(attack.statScaler) * BalanceConstants.DAMAGE_MULTIPLIER;
            var objetive = TargetsProcessor.GetClosestEnemy(parent.Position);
            objetive.defenseSys.BeAttacked(new DamageData(value, attack.damageType));

            OnHitMade?.Invoke();
            OnAttackCasted?.Invoke();
        }
    }

    public enum DamageType
    {
        PHYSICAL,
        MAGICAL
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