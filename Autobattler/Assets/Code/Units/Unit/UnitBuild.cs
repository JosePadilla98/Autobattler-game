using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.Units
{
    [CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Unit/BuildedUnitBlueprint", order = 2)]
    public class UnitBuild : ScriptableObject
    {
        public MutationModel[] baseMutations;
        public int level;
        public MutationModel[] mutations;
        public Sprite sprite;
    }
}