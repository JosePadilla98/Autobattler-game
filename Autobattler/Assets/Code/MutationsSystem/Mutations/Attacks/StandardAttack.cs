using System;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Combat.CombatSystems;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations.Attacks
{
    [CreateAssetMenu(fileName = "StandardAttack", menuName = "ScriptableObjects/MutationsSystem/Mutations/Attacks/Standard")]
    public class StandardAttack : MutationModel, IModifyFighter
    {
        void IModifyFighter.AttachToFighter(int order, int key, Fighter fighter)
        {
            ChargerSystem chargerSystem = fighter.ChargerSys;

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

        void IModifyFighter.UnattachToFighter(int key, Fighter fighter)
        {
            throw new NotImplementedException();
        }

        private void Cast(Fighter combatInstance)
        {
            var attackSystem = combatInstance.attackSys;

            var attackData = new AttackData(100f, StatsNames.PHYSICAL_ATTACK, DamageType.PHYSICAL);
            attackSystem.LaunchSimpleAttack(attackData);
        }

       
    }
}