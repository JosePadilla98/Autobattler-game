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

    /// <summary>
    /// MagicEncumbrance: multiplicador a la fatiga que aplica una habilidad
    /// </summary>
    [System.Serializable]
    public struct Stats
    {
        public float health;
        public float attack;
        public float attackPower;
        public float attackSpeed;
        

        public float magic;
        public float manaRegen;
        

        public float defense;
        public float magicDefense;
        public float evasion;

        public float cooldownReduction;

        public float attackEncumbrance;
        public float magicEncumbrance;
        public float reinvigoration;
        public float vigor;

        public float precision;
        public float attackPrecision;
        public float magicPrecision;
    }
}