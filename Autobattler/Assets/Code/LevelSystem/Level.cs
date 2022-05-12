using System;
using Autobattler.Unit.Unit;
using UnityEngine;

namespace Autobattler.LevelSystem
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 3)]
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