using System;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units.Combat.CombatSystems
{
    public class AttackSystem : CombatSystem
    {
        public Action OnAttackCasted;
        public Action OnHitMade;

        public AttackSystem(Fighter parent)
            : base(parent) { }

        public StatsContainer StatsContainer => parent.StatsContainer;

        /// <summary>
        /// Returns fighter who has been attacked
        /// </summary>
        /// <param name="attack"></param>
        public Fighter LaunchSimpleAttack(AttackData attack)
        {
            var value =
                attack.scaleFactor
                * StatsContainer.GetStatValue(attack.statScaler)
                * BalanceConstants.DAMAGE_MULTIPLIER;
            Fighter objetive = TargetsProcessor.GetClosestEnemy(parent.Position);
            objetive.defenseSys.BeAttacked(new DamageData(value, attack.damageType));

            OnHitMade?.Invoke();
            OnAttackCasted?.Invoke();

            return objetive;
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
