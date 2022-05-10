using Assets.Code.Backend.RunLogic.Combat.Fighter;
using Auttobattler.Backend.RunLogic.Management;
using Auttobattler.MutationsSystem;
using UnityEngine;

namespace Auttobattler.Backend.MutationSystem
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/Mutations/SkinRegeneration")]
    public class SkinRegeneration : MutationModel
    {
        [SerializeField]
        protected StatModifier[] statModifiers;

        public override void AttachToCombatModules(int order, int key, Fighter unit)
        {
            throw new System.NotImplementedException();
        }

        public override void ModifyStats(Stats stats)
        {
            throw new System.NotImplementedException();
        }

        public override void UnattachToCombatModules(int key, Fighter fighter)
        {
            throw new System.NotImplementedException();
        }

        public override void UnmodifyStats(Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }
}
