using UnityEngine;

namespace AutobattlerOld.MutationsSystem.Mutations
{
    [CreateAssetMenu(fileName = "MutationsPack", menuName = "ScriptableObjects/MutationsSystem/MutationsPack")]
    public class MutationsPack : ScriptableObject
    {
        public MutationModel[] mutation;
        public int rarity;
    }
}