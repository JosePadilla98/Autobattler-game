using UnityEngine;

namespace Auttobattler.Backend.MutationSystem
{
    [CreateAssetMenu(fileName = "MutationsDatabase", menuName = "ScriptableObjects/MutationsSystem/MutationsDatabase")]
    public class MutationsDatabase : ScriptableObject
    {
        public MutationsPack[] mutationsPacks;
    }
}
