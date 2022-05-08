using Auttobattler.Backend.MutationSystem;
using UnityEngine;

namespace Auttobattler.Backend.Run.ManagementState
{
    [CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Unit/BuildedUnitBlueprint", order = 2)]
    public class UnitBuild : ScriptableObject
    {
        public int level;
        public Sprite sprite;
        public MutationModel[] baseMutations;
        public MutationModel[] mutations;
    }
}


