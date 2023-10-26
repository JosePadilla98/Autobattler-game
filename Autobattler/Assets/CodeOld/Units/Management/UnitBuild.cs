using System;
using AutobattlerOld.MutationsSystem.Mutations;
using UnityEngine;

namespace AutobattlerOld.Units.Management
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