using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    [CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/CreatureBlueprint", order = 1)]
    public class CreatureBlueprint : ScriptableObject
    {
        public string creatureName;
        public Sprite sprite; 
        public Stats stats;
    }

    [System.Serializable]
    public class Stats
    {
        public float health;
        public float attack;
        public float habilityPower;
        public float attackSpeed;
        public float manaRegen;
        public float cooldownReduction;

        public float encumbrance;
        public float Reinvigoration;
        public float maxFatigue;
    }
}