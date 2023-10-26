using UnityEngine;

namespace AutobattlerOld.MutationsSystem.Mutations
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/MutationsDatabase")]
    public class MutationsDatabase : ScriptableObject
    {
        public MutationsPack[] mutationsPacks;
    }
}