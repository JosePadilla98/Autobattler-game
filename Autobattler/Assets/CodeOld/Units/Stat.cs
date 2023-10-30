﻿using System;
using System.Collections.Generic;
using AutobattlerOld.Configs.Balance;
using AutobattlerOld.MutationsSystem.Effects;

namespace AutobattlerOld.Units
{
    public class Stat : ICloneable, IValueExpositor
    {
        private const bool SOME_STATS_SCALES_BY_LEVEL = false;
        public float baseStat;

        /// <summary>
        ///  Passed by reference
        /// </summary>
        private readonly int level;
        public bool scalesByLevel;

        private List<float> linearModifiers = new();
        private List<float> percentualModifiers = new();

        public Action OnValueChanged { get; set; }

        public Stat(float baseStat)
        {
            this.baseStat = baseStat;
            scalesByLevel = false;
            level = -1;
        }

        public Stat(float baseStat, ref int level)
        {
            this.baseStat = baseStat;
            this.level = level;
            scalesByLevel = true;
        }

        public object Clone()
        {
            var clone = (Stat)MemberwiseClone();
            clone.percentualModifiers = new List<float>(percentualModifiers);
            clone.linearModifiers = new List<float>(linearModifiers);

            return clone;
        }

        private float GetWithoutLevelIncrement()
        {
            var value = baseStat;
            foreach (var item in linearModifiers)
                value += item;
            foreach (var item in percentualModifiers)
                value += item * value / 100;

            return value;
        }

        public float Get()
        {
            var value = GetWithoutLevelIncrement();

            if (!scalesByLevel)
                return value;

            var increment = (level - 1) * value * BalanceConstants.LEVEL_STATS_INCREMENT_FACTOR;
            value += increment;

            return value;
        }

        public float GetOnlyWithLinearModifiers()
        {
            var value = baseStat;
            foreach (var item in linearModifiers)
                value += item;
            return value;
        }

        public void AddModifier(ModifierType type, float modifier)
        {
            if (type == ModifierType.LINEAL)
                linearModifiers.Add(modifier);
            else
                percentualModifiers.Add(modifier);

            OnValueChanged?.Invoke();
        }

        public void RemoveModifier(ModifierType type, float modifier)
        {
            if (type == ModifierType.LINEAL)
                linearModifiers.Remove(modifier);
            else
                percentualModifiers.Remove(modifier);

            OnValueChanged?.Invoke();
        }

        public static bool CheckIfScalesByLevel(OldStatsNames statName)
        {
            if (!SOME_STATS_SCALES_BY_LEVEL)
                return false;

            switch (statName)
            {
                case OldStatsNames.PHYSICAL_ATTACK:
                case OldStatsNames.MAGICAL_ATTACK:
                case OldStatsNames.PHYSICAL_DEFENSE:
                case OldStatsNames.MAGICAL_DEFENSE:
                    return true;

                default:
                    return false;
            }
        }
    }
}
