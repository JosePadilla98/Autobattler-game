using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.MutationsSystem;

namespace Auttobattler.Scriptables
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


