using System;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations.Attacks
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/Mutations/Attacks/Standard")]

    public class StandardAttack : MutationModel
    {
        [SerializeField] protected StatModifier[] statModifiers;

        public override void ModifyStats(Stats stats)
        {
            Stats.ApplyStatsModifiers(statModifiers, stats);
        }

        public override void UnmodifyStats(Stats stats)
        {
            Stats.UnapplyStatsModifiers(statModifiers, stats);
        }

        public override void AttachToCombatModules(int order, int key, Fighter fighter)
        {
            var chargerSystem = fighter.ChargerSys;

            var data = new ChargeableData();
            Action OnRecharged = null;
            var chargeable = ChargeableItem.Pool.Get().Inflate(data, OnRecharged);
            chargerSystem.AddToWaitingList(chargeable);

            OnRecharged = () =>
            {
                Cast(fighter);

                //Recursively add to waiting list
                chargerSystem.rechargingItems.Remove(key);
                chargerSystem.AddToWaitingList(chargeable);
            };
        }

        public override void UnattachToCombatModules(int key, Fighter fighter)
        {
            //Buscar en waiting y elimin
        }

        private void Cast(Fighter combatInstance)
        {
            var attackSystem = combatInstance.attackSys;

            var attackData = new AttackData(100f, StatsNames.PHYSICAL_ATTACK, DamageType.PHYSICAL);
            attackSystem.LaunchSimpleAttack(attackData);
        }
    }
}