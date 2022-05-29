using System;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.LevelSystem
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