using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Mutators
{
    [CreateAssetMenu(fileName = "StatModifier", menuName = "ScriptableObjects/Mutators/StatModifier", order = 3)]
    public class StatModifier : UnitMutator
    {
        public StatsNames statName;
        public ModifierType type;
        public float value;
    }

    public enum ModifierType
    {
        LINEAR, PERCENTAGE
    }
}
