using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Mutators;

namespace Auttobattler.Scriptables
{
    [CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Unit/BuildedUnitBlueprint", order = 2)]
    public class BuildedUnitBlueprint : ScriptableObject
    {
        public int level;
        public BaseUnitBlueprint baseBlueprint;
        public UnitMutator[] mutators;
    }
}


