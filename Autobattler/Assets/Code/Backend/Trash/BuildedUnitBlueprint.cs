using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Mutators;
using Auttobattler.Ultimates;

namespace Auttobattler.Scriptables
{
    [CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Unit/BuildedUnitBlueprint", order = 2)]
    public class UnitBuild : ScriptableObject
    {
        public int level;
        public BaseUnitBlueprint baseBlueprint;
        public UltimateScriptable ultimate;
        public UnitMutator[] mutators;
    }
}


