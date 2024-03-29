﻿using System;
using System.Collections.Generic;
using Autobattler.Configs;
using Autobattler.MutationsSystem;

namespace Autobattler.Units.Management
{
    public class Stat : ICloneable, IValueExpositor
    {
        private readonly float baseStat;

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

        public float GetWithoutLevelIncrement()
        {
            var value = baseStat;
            foreach (var item in linearModifiers) value += item;
            foreach (var item in percentualModifiers) value += item * value/100;

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
    }
}