using Auttobattler.Backend.MutationSystem;
using UnityEngine;

namespace Auttobattler.Backend.RunLogic.Management
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

