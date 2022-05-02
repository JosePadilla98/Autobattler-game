using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/MutationsDatabase")]
    public class MutationsDatabase : ScriptableObject
    {
        public MutationsPack[] mutationsPacks;
    }
}
