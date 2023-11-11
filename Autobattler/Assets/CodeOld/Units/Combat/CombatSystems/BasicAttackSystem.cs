using System;
using AutobattlerOld.Configs.Balance;
using UnityEngine;

namespace AutobattlerOld.Units.Combat.CombatSystems
{
    public class BasicAttackSystem : CombatSystem
    {
        public Action OnAttackLaunched;
        public Action OnHitMade;

        public BasicAttackSystem(Fighter parent)
            : base(parent) { }

        public StatsContainer StatsContainer => parent.StatsContainer;
        private CombatValue AttackProgress => parent.combatValues.basicAttackProgress;

        /// <summary>
        /// Returns fighter who has been attacked
        /// </summary>
        /// <param name="attack"></param>
        public Fighter LaunchSimpleAttack(AttackData attack)
        {
            var attackPower =
                attack.percentage
                * StatsContainer.GetStatValue(attack.statUsed)
                * BalanceConstants.DAMAGE_MULTIPLIER;

            Fighter objetive = TargetsProcessor.GetClosestEnemy(parent.Position);

            OnAttackLaunched?.Invoke();
            if (objetive.ReceiveAttack(new DamageData(attackPower)))
            {
                OnHitMade?.Invoke();
            }

            if (App.DebugController.combat)
            {
                Debug.Log(parent.name + " triggers basic attack to " + objetive.name);
            }

            return objetive;
        }

        public void Refresh()
        {
            AttackProgress.Value += StatsContainer.GetStatValue(StatsNames.ATTACK_SPEED);
            if (AttackProgress.Value > BalanceConstants.BASIC_ATTACK_PROGRESS_TO_BE_TRIGGERED)
            {
                AttackProgress.Value -= BalanceConstants.BASIC_ATTACK_PROGRESS_TO_BE_TRIGGERED;
                LaunchSimpleAttack(new AttackData(1f, StatsNames.STRENGTH));
            }
        }
    }
}
