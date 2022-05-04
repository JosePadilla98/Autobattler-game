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

    }
}
