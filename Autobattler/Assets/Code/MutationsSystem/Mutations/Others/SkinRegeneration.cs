using System;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations.Others
{
    [CreateAssetMenu(fileName = "MutationsDatabase",
        menuName = "ScriptableObjects/MutationsSystem/Mutations/SkinRegeneration")]
    public class SkinRegeneration : MutationModel
    {
        [SerializeField] protected StatModifier[] statModifiers;

        public override void AttachToCombatModules(int order, int key, Fighter unit)
        {
            throw new NotImplementedException();
        }

        public override void ModifyStats(Stats stats)
        {
            throw new NotImplementedException();
        }

        public override void UnattachToCombatModules(int key, Fighter fighter)
        {
            throw new NotImplementedException();
        }

        public override void UnmodifyStats(Stats stats)
        {
            throw new NotImplementedException();
        }
    }
}