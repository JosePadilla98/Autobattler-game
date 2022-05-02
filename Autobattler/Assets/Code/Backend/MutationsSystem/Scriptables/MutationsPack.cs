using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    [CreateAssetMenu(fileName = "MutationsPack", menuName = "ScriptableObjects/Mutations/MutationsPack")]
    public class MutationsPack : ScriptableObject
    {
        public int rarity;
        public Mutation[] mutation;
    }
}
