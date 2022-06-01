using System;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Combat.CombatSystems;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.MutationsSystem.Mutations.Attacks
{
    [CreateAssetMenu(fileName = "StandardMutation", menuName = "ScriptableObjects/MutationsSystem/Mutations/Standard")]
    public class StandardMutation : MutationModel, IModifyStats
    {
        [SerializeField] 
        protected StatsModifier statModifiers;

        public override string GetDescription(int timesStacked)
        {
            return statModifiers.GetDescription(timesStacked, colorsConfig);
        }

        public void ModifyStats(StatsContainer statsContainer)
        {
            statModifiers.ApplyStatsModifiers(statsContainer);
        }

        public void UnmodifyStats(StatsContainer statsContainer)
        {
            statModifiers.UnapplyStatsModifiers(statsContainer);
        }
    }
}