using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Scriptables
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 3)]
    public class Level : ScriptableObject
    {
        public SummonsPerSide[] sidesInfo;
    }

    [System.Serializable]
    public class SummonsPerSide
    {
        public Side side;
        public BuildedUnitBlueprint[] frontColumn;
        public BuildedUnitBlueprint[] backColumn;
    }

}
