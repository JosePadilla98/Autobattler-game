using System;
using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.Units.Management
{
    [CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Unit/BuildedUnitBlueprint", order = 2)]
    public class UnitBuild : ScriptableObject
    {
        public int level;
        [Space(20)]
        public MutationModel[] permanentMutations;
        [Space(20)]
        public MutationModel[] mutations;
        public Sprite sprite;
        public String name = "NoName";
    }
}