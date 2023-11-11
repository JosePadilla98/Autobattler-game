using System;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.LevelSystem
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelSystem/Level")]
    public class Level : ScriptableObject
    {
        public InvocationsData enemies;
    }

    [Serializable]
    public class InvocationsData
    {
        public UnitBuild[] backColumn;
        public UnitBuild[] frontColumn;
    }
}