using System;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Combat.CombatSystems;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations.Attacks
{
    [CreateAssetMenu(fileName = "StandardMutation", menuName = "ScriptableObjects/MutationsSystem/Mutations/Standard")]
    public class StandardMutation : MutationModel
    {
        [SerializeField] 
        protected StatModifier[] statModifiers;

        [TextArea]
        [SerializeField]
        private String description;

        public override string GetDescription()
        {
            return description;
        }

        public override void ModifyStats(Stats stats)
        {
            Stats.ApplyStatsModifiers(statModifiers, stats);
        }

        public override void UnmodifyStats(Stats stats)
        {
            Stats.UnapplyStatsModifiers(statModifiers, stats);
        }

        public override void AttachToCombatModules(int order, int key, Fighter unit)
        {

        }
        
        public override void UnattachToCombatModules(int key, Fighter unit)
        {

        }
    }
}