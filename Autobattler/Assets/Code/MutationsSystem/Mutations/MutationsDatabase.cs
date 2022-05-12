using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/MutationsDatabase")]
    public class MutationsDatabase : ScriptableObject
    {
        public MutationsPack[] mutationsPacks;
    }
}