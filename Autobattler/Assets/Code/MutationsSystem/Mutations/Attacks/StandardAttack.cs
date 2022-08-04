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
        [SerializeField]
        private float scaleFactor = 100f;
        [SerializeField]
        private StatsNames stat;
        [SerializeField]
        private DamageType damageType;
        [SerializeField] 
        private ChargeableData chargeableData;

        void IModifyFighter.AttachToFighter(int order, int key, Fighter fighter)
        {
            ChargerSystem chargerSystem = fighter.ChargerSys;
            
            Action OnRecharged = null;
            chargeableData.priority = order;

            ChargeableItem chargeable = ChargeableItem.Pool.Get().Inflate(key, chargeableData, null);
            OnRecharged = () =>
            {
                Cast(fighter);

                //Recursively add to waiting list
                chargerSystem.rechargingItems.Remove(chargeable);
                chargerSystem.AddToWaitingList(chargeable);
            };
            chargeable.OnRecharged = OnRecharged;
            chargerSystem.AddToWaitingList(chargeable);
        }

        void IModifyFighter.UnattachToFighter(int key, Fighter fighter)
        {
            throw new NotImplementedException();
        }

        private void Cast(Fighter combatInstance)
        {
            Debug.Log(combatInstance.name + " uses attack");

            var attackSystem = combatInstance.attackSys;

            var attackData = new AttackData(scaleFactor, stat, damageType);
            //attackSystem.LaunchSimpleAttack(attackData);
        }
    }
}