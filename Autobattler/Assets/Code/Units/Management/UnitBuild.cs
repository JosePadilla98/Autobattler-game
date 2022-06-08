using System;
using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.Units.Management
{
    [CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Unit/BuildedUnitBlueprint")]
    public class UnitBuild : ScriptableObject
    {
        public int level = 1;
        [Space(20)]
        public MutationModel[] mutations;
        public Sprite sprite;
        public String name = "NoName";
    }
}