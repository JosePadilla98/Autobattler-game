using Autobattler.MutationsSystem.Effects;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations.Others
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