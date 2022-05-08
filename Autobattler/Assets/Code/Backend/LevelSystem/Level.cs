using Auttobattler.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 3)]
    public class Level : ScriptableObject
    {
        public InvocationsData invocationsData;
    }

    [System.Serializable]
    public class InvocationsData
    {
        public UnitBuild[] frontColumn;
        public UnitBuild[] backColumn;
    }

}
