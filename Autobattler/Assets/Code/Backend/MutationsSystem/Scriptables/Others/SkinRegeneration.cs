using Auttobattler.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
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

        public override void UnattachToCombatModules(int key, Fighter unit)
        {
            throw new System.NotImplementedException();
        }

        public override void UnmodifyStats(Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }
}
