using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Mutators;
using Auttobattler.Ultimates;
using System;
using Auttobattler.MutationsSystem;

namespace Auttobattler
{
    public enum StatsNames
    {
        HEALTH, HEALTH_REGEN,
        PHYSICAL_ATTACK, MAGICAL_ATTACK,
        PHYSICAL_DEFENSE, MAGICAL_DEFENSE,
        PHYSICAL_SPEED, MAGICAL_SPEED,
        VIGOR, REINVIGORATION,
        MAX_MANA, MANA_REGEN,
        INTELLECT,

        WEIGHT_CAPACITY,

        PHYSICAL_FATIGUE, MAGICAL_FATIGUE,
        BASE_ATTACK_DURATION
    }

    public class Stats
    {
        private Dictionary<StatsNames, Stat> valuePairs;
        public int level;

        public Stats()
        {
            valuePairs = StandardStats();
        }

        public Stat GetStat(StatsNames name)
        {
            Stat stat;
            valuePairs.TryGetValue(name, out stat);
            return stat;
        }

        public float GetStatValue(StatsNames name)
        {
            Stat stat = GetStat(name);
            float value = stat.Get;

            return (!stat.scalesByLevel) ? value
               : GetValueWithLevelModifier(value, level);
        }

        private float GetValueWithLevelModifier(float value, int level)
        {
            float increment = ((level - 1) * value * Constants.LEVEL_STATS_INCREMENT_FACTOR);
            return value + increment;
        }

        private Dictionary<StatsNames, Stat> StandardStats()
        {
            Dictionary<StatsNames, Stat> dic = new Dictionary<StatsNames, Stat>
            {
                { StatsNames.HEALTH, new Stat(25f) },
                { StatsNames.HEALTH_REGEN, new Stat(1f) },

                { StatsNames.PHYSICAL_ATTACK, new Stat(25f, true) },
                { StatsNames.MAGICAL_ATTACK, new Stat(25f, true) },

                { StatsNames.PHYSICAL_DEFENSE, new Stat(25f, true) },
                { StatsNames.MAGICAL_DEFENSE, new Stat(25f, true) },

                { StatsNames.PHYSICAL_SPEED, new Stat(25f) },
                { StatsNames.MAGICAL_SPEED, new Stat(25f) },

                { StatsNames.VIGOR, new Stat(25f) },
                { StatsNames.REINVIGORATION, new Stat(1f) },

                { StatsNames.MAX_MANA, new Stat(25f) },
                { StatsNames.MANA_REGEN, new Stat(1f) },

                { StatsNames.INTELLECT, new Stat(25f) },

                { StatsNames.WEIGHT_CAPACITY, new Stat(1f) },

                { StatsNames.PHYSICAL_FATIGUE, new Stat(1f) },
                { StatsNames.MAGICAL_FATIGUE, new Stat(1f) },
            };

            return dic;
        }

        public static void ApplyStatsModifiers(StatModifier[] modifiers, Stats stats)
        {
            foreach (var modifier in modifiers)
            {
                var stat = stats.GetStat(modifier.statName);

                if (modifier.type == ModifierType.LINEAL)
                    stat.linearModifiers.Add(modifier.value);
                else
                    stat.percentualModifiers.Add(modifier.value);
            }
        }

        public static void UnapplyStatsModifiers(StatModifier[] modifiers, Stats stats)
        {
            foreach (var modifier in modifiers)
            {
                var stat = stats.GetStat(modifier.statName);

                if (modifier.type == ModifierType.LINEAL)
                    stat.linearModifiers.Remove(modifier.value);
                else
                    stat.percentualModifiers.Remove(modifier.value);
            }
        }
    }

    public class Stat : ICloneable
    {
        private float baseStat;
        public List<float> percentualModifiers = new List<float>();
        public List<float> linearModifiers = new List<float>();

        public bool scalesByLevel;

        public delegate void CurrentValueChanged(float value);
        public event CurrentValueChanged OnCurrentValueChanged;

        public float Get
        {
            get
            {
                float output = baseStat;
                foreach (var item in linearModifiers)
                {
                    output += item;
                }

                foreach (var item in percentualModifiers)
                {
                    output *= item;
                }

                return output;
            }
        }

        public Stat(float baseStat, bool scalesByLevel = false)
        {
            this.baseStat = baseStat;
            this.scalesByLevel = scalesByLevel;
        }

        public object Clone()
        {
            var clone = (Stat)this.MemberwiseClone();
            clone.percentualModifiers = new List<float>(percentualModifiers);
            clone.linearModifiers = new List<float>(linearModifiers);

            return clone;
        }
    }

}


