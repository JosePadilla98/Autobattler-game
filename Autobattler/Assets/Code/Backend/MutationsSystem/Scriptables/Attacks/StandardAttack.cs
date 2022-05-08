using Auttobattler.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/Mutations/Attacks/Standard")]
    public class StandardAttack : MutationModel
    {
        [SerializeField]
        protected StatModifier[] statModifiers;

        public override void ModifyStats(Stats stats)
        {
            Stats.ApplyStatsModifiers(statModifiers, stats);
        }

        public override void UnmodifyStats(Stats stats)
        {
            Stats.UnapplyStatsModifiers(statModifiers, stats);
        }

        public override void AttachToCombatModules(int order, int key, Fighter combatInstance)
        {
            ChargerSystem chargerSystem = combatInstance.ChargerSys;

            ChargeableData data = new ChargeableData();
            Action OnRecharged = null;
            ChargeableItem chargeable = ChargeableItem.Pool.Get().Inflate(data, OnRecharged);
            chargerSystem.AddToWaitingList(chargeable);

            OnRecharged = () =>
            {
                Cast(combatInstance);

                //Recursively add to waiting list
                chargerSystem.rechargingItems.Remove(key);
                chargerSystem.AddToWaitingList(chargeable);
            };
        }

        public override void UnattachToCombatModules(int key, Fighter unit)
        {
            //Buscar en waiting y elimin
        }

        private void Cast(Fighter combatInstance)
        {
            AttackSystem attackSystem = combatInstance.attackSys;

            AttackData attackData = new AttackData(100f, StatsNames.PHYSICAL_ATTACK, DamageType.PHYSICAL);
            attackSystem.LaunchSimpleAttack(attackData);
        }
    }
}
