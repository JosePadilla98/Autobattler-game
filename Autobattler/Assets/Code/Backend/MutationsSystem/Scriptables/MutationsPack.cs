using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Backend.MutationSystem
{
    [CreateAssetMenu(fileName = "MutationsPack", menuName = "ScriptableObjects/MutationsSystem/MutationsPack")]
    public class MutationsPack : ScriptableObject
    {
        public int rarity;
        public MutationModel[] mutation;
    }
}
