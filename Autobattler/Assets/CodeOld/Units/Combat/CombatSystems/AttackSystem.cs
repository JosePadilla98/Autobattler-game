using System;
using AutobattlerOld.Configs.Balance;

namespace AutobattlerOld.Units.Combat.CombatSystems
{
    public class BasicAttackSystem : CombatSystem
    {
        public Action OnAttackCasted;
        public Action OnHitMade;

        public BasicAttackSystem(Fighter parent)
            : base(parent) { }

        public StatsContainer StatsContainer => parent.StatsContainer;

        /// <summary>
        /// Returns fighter who has been attacked
        /// </summary>
        /// <param name="attack"></param>
        public Fighter LaunchSimpleAttack(AttackData attack)
        {
            var value =
                attack.power
                * StatsContainer.GetStatValue(attack.statUsed)
                * BalanceConstants.DAMAGE_MULTIPLIER;
            Fighter objetive = TargetsProcessor.GetClosestEnemy(parent.Position);
            objetive.defenseSys.BeAttacked(new DamageData(value));

            OnHitMade?.Invoke();
            OnAttackCasted?.Invoke();

            return objetive;
        }
    }
}
