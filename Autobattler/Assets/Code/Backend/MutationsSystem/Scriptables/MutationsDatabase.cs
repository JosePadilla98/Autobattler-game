using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/Mutations/MutationsDatabase")]
    public class MutationsDatabase : ScriptableObject
    {
        public MutationsPack[] mutationsPacks;
    }
}
