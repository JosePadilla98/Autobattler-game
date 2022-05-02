using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
{
    [System.Serializable]
    public class StatModifier
    {
        public StatsNames statName;
        public ModifierType type;
        public float value;
    }

    public enum ModifierType
    {
        LINEAL, PERCENTAGE
    }
}