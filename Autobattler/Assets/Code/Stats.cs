using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using System;

namespace Auttobattler
{
    [System.Serializable]
    public struct Stats
    {
        public float health;

        [Space(10)]
        [Header("Attack")]
        public float attack;
        public float attackPower;
        public float attackSpeed;
        public float attackDuration;

        [Space(10)]
        [Header("Magic")]
        public float magic;
        public float manaRegen;
        public float cooldownReduction;

        [Space(10)]
        [Header("Critics")]
        public float criticMultiplier;
        public float physicalCriticChance;
        public float magicalCriticChance;

        [Space(10)]
        [Header("Defenses")]
        public float defense;
        public float magicDefense;
        public float physicalEvasion;
        public float magicalEvasion;
        public float physicalReduction;
        public float magicReduction;

        [Space(10)]
        [Header("Vigor")]
        public float attackEncumbrance;
        public float magicEncumbrance;
        public float reinvigoration;
        public float vigor;

        [Space(10)]
        [Header("Precision")]
        public float attackPrecision;
        public float magicPrecision;
    }

    public enum StatsNamesEnum
    {
        ATTACK
    }

    /// <summary>
    /// Build only keeps in mind the unit mutators, not the objects. 
    /// This is cause the effects of objects can be disabled in battle
    /// </summary>
    public class BuildedUnit : ICloneable
    {
        public BaseUnitBlueprint baseBlueprint;

        #region MODIFIED BY LEVEL
        public int level;
        
        public BuildStat attack;
        public BuildStat defense;
        #endregion

        public BuildStat health;

        public BuildStat attackPower;
        public BuildStat attackSpeed;
        public BuildStat attackDuration;

        public BuildedUnit(BuildedUnitBlueprint blueprint)
        {
            this.baseBlueprint = blueprint.baseBlueprint;
            this.level = blueprint.level;

            Stats baseStats = baseBlueprint.stats;
            this.health = new BuildStat(baseStats.health);
            this.attack = new BuildStat(baseStats.attack);
            this.defense = new BuildStat(baseStats.defense);

            this.attackPower = new BuildStat(baseStats.attackPower);
            this.attackSpeed = new BuildStat(baseStats.attackSpeed);
            this.attackDuration = new BuildStat(baseStats.attackDuration);
        }

        public object Clone()
        {
            var clone = (BuildedUnit)this.MemberwiseClone();
            return clone;
        }
    }

    public class BuildStat : ICloneable
    {
        private float baseStat;
        public List<float> modifiers = new List<float>();
        public List<float> linearModifiers = new List<float>();

        public float Get
        {
            get
            {
                float output = baseStat;
                foreach (var item in linearModifiers)
                {
                    output += item;
                }

                foreach (var item in modifiers)
                {
                    output *= item;
                }

                return output;
            }
        }

        public BuildStat(float baseStat)
        {
            this.baseStat = baseStat;
        }

        public delegate void CurrentValueChanged(float value);
        public event CurrentValueChanged OnCurrentValueChanged;


        public object Clone()
        {
            var clone = (BuildStat)this.MemberwiseClone();
            clone.modifiers = new List<float>(modifiers);
            clone.linearModifiers = new List<float>(linearModifiers);

            return clone;
        }
    }
}


