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

        public override void AttachToCombatModules(int order, int key, UnitCombatInstance combatInstance)
        {
            EnergySystem energySystem = combatInstance.energySys;
            ChargerSystem chargerSystem = combatInstance.ChargerSys;
            AttackSystem attackSystem = combatInstance.attackSys;

            ChargeableData data = new ChargeableData();
            Action OnRecharged = null;
            ChargeableItem chargeable = ChargeableItem.Pool.Get().Inflate(data, OnRecharged);
            chargerSystem.AddToWaitingList(chargeable);

            OnRecharged = () =>
            {
                //Cast

                //Recursively add to waiting list
                chargerSystem.rechargingItems.Remove(key);
                chargerSystem.AddToWaitingList(chargeable);
            };
        }

        public override void UnattachToCombatModules(int key, UnitCombatInstance unit)
        {
            //Buscar en waiting y elimin
        }
    }
}
