using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Mutators;
using Auttobattler.Ultimates;
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
        public float maxMana;
        public float cooldownReduction;

        [Space(10)]
        [Header("Ultimate")]
        public float ultimateRegen;

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

    public enum StatsNames
    {
        ATTACK
    }

    public class BuildedUnit : ICloneable
    {
        public BuildStatsWrapper statsWrapper;
        public List<UnitMutator> mutators;
        public UltimateScriptable ultScriptable;

        public BuildedUnit(BuildedUnitBlueprint blueprint)
        {
            statsWrapper = new BuildStatsWrapper(blueprint);
            mutators = new List<UnitMutator>(blueprint.mutators);
            ultScriptable = blueprint.ultimate;

            //StatsModifiers
            foreach (var mutator in mutators)
            {
                if (!(mutator is StatModifier))
                    return;

                StatModifier modifier = (StatModifier)mutator;
                BuildStat statToModify = null;

                switch (modifier.statName)
                {
                    case StatsNames.ATTACK:
                        statToModify = statsWrapper.attack;
                        break;
                }

                List<float> modifierList = (modifier.type == ModifierType.LINEAL) ?
                    modifierList = statToModify.linearModifiers : modifierList = statToModify.modifiers;

                modifierList.Add(modifier.value);
            }
        }

        public object Clone()
        {
            var clone = (BuildedUnit)this.MemberwiseClone();
            return clone;
        }
    }

    public class BuildStatsWrapper
    {
        #region MODIFIED BY LEVEL
        public int level;

        public BuildStat attack;
        public BuildStat magic;
        public BuildStat defense;
        public BuildStat magicDefense;
        #endregion

        public BuildStat health;

        public BuildStat attackPower;
        public BuildStat attackSpeed;
        public BuildStat attackDuration;

        public BuildStat ultimateRegen;

        public BuildStatsWrapper(BuildedUnitBlueprint blueprint)
        {
            Stats baseStats = blueprint.baseBlueprint.stats;
            health = new BuildStat(baseStats.health);
            attack = new BuildStat(baseStats.attack);
            magic = new BuildStat(baseStats.magic);
            defense = new BuildStat(baseStats.defense);
            magicDefense = new BuildStat(baseStats.magicDefense);

            attackPower = new BuildStat(baseStats.attackPower);
            attackSpeed = new BuildStat(baseStats.attackSpeed);
            attackDuration = new BuildStat(baseStats.attackDuration);

            ultimateRegen = new BuildStat(baseStats.ultimateRegen);
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


