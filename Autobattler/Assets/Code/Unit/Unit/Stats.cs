using System;
using System.Collections.Generic;
using Autobattler.Configs;
using Autobattler.MutationsSystem;

namespace Autobattler.Unit.Unit
{
    public enum StatsNames
    {
        HEALTH,
        HEALTH_REGEN,
        PHYSICAL_ATTACK,
        MAGICAL_ATTACK,
        PHYSICAL_DEFENSE,
        MAGICAL_DEFENSE,
        PHYSICAL_SPEED,
        MAGICAL_SPEED,
        VIGOR,
        REINVIGORATION,
        MANA,
        MANA_REGEN,
        INTELLECT,

        WEIGHT_CAPACITY,

        PHYSICAL_FATIGUE,
        MAGICAL_FATIGUE
    }

    public class Stats
    {
        public int level;
        private readonly Dictionary<StatsNames, Stat> valuePairs;

        public Stats()
        {
            level = 1;
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
            var stat = GetStat(name);
            return stat.Get();
        }

        private Dictionary<StatsNames, Stat> StandardStats()
        {
            var dic = new Dictionary<StatsNames, Stat>
            {
                { StatsNames.HEALTH, new Stat(25f) },
                { StatsNames.HEALTH_REGEN, new Stat(1f) },

                { StatsNames.PHYSICAL_ATTACK, new Stat(25f, ref level) },
                { StatsNames.MAGICAL_ATTACK, new Stat(25f, ref level) },

                { StatsNames.PHYSICAL_DEFENSE, new Stat(25f, ref level) },
                { StatsNames.MAGICAL_DEFENSE, new Stat(25f, ref level) },

                { StatsNames.PHYSICAL_SPEED, new Stat(25f) },
                { StatsNames.MAGICAL_SPEED, new Stat(25f) },

                { StatsNames.VIGOR, new Stat(25f) },
                { StatsNames.REINVIGORATION, new Stat(1f) },

                { StatsNames.MANA, new Stat(25f) },
                { StatsNames.MANA_REGEN, new Stat(1f) },

                { StatsNames.INTELLECT, new Stat(25f) },

                { StatsNames.WEIGHT_CAPACITY, new Stat(1f) },

                { StatsNames.PHYSICAL_FATIGUE, new Stat(1f) },
                { StatsNames.MAGICAL_FATIGUE, new Stat(1f) }
            };

            return dic;
        }

        public static void ApplyStatsModifiers(StatModifier[] modifiers, Stats stats)
        {
            foreach (var modifier in modifiers)
            {
                var stat = stats.GetStat(modifier.statName);
                stat.AddModifier(modifier.type, modifier.value);
            }
        }

        public static void UnapplyStatsModifiers(StatModifier[] modifiers, Stats stats)
        {
            foreach (var modifier in modifiers)
            {
                var stat = stats.GetStat(modifier.statName);
                stat.RemoveModifier(modifier.type, modifier.value);
            }
        }
    }

    public class Stat : ICloneable
    {
        private readonly float baseStat;

        /// <summary>
        ///     This int is passed by reference
        /// </summary>
        private readonly int level;

        private List<float> linearModifiers = new();

        public Action onValueChanged;
        private List<float> percentualModifiers = new();
        public bool scalesByLevel;

        public Stat(float baseStat)
        {
            this.baseStat = baseStat;
            scalesByLevel = false;
            level = 0;
        }

        public Stat(float baseStat, ref int level)
        {
            this.baseStat = baseStat;
            scalesByLevel = true;
            this.level = level;
        }

        public object Clone()
        {
            var clone = (Stat)MemberwiseClone();
            clone.percentualModifiers = new List<float>(percentualModifiers);
            clone.linearModifiers = new List<float>(linearModifiers);

            return clone;
        }

        public float GetWithoutLevelIncrement()
        {
            var value = baseStat;
            foreach (var item in linearModifiers) value += item;

            foreach (var item in percentualModifiers) value *= item;

            return value;
        }

        public float Get()
        {
            var value = GetWithoutLevelIncrement();

            if (!scalesByLevel) return value;

            var increment = (level - 1) * value * BalanceConstants.LEVEL_STATS_INCREMENT_FACTOR;
            value += increment;

            return value;
        }

        public void AddModifier(ModifierType type, float modifier)
        {
            if (type == ModifierType.LINEAL)
                linearModifiers.Add(modifier);
            else
                percentualModifiers.Add(modifier);

            onValueChanged();
        }

        public void RemoveModifier(ModifierType type, float modifier)
        {
            if (type == ModifierType.LINEAL)
                linearModifiers.Remove(modifier);
            else
                percentualModifiers.Remove(modifier);

            onValueChanged();
        }
    }
}