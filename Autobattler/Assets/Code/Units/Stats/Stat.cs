using System;
using System.Collections.Generic;

namespace Autobattler
{
    public class Stat : ICloneable
    {
        public float baseStat;

        private List<float> linearModifiers = new();
        private List<float> percentualModifiers = new();

        public Action OnValueChanged { get; set; }

        public Stat(float baseStat)
        {
            this.baseStat = baseStat;
        }

        public object Clone()
        {
            var clone = (Stat)MemberwiseClone();
            clone.percentualModifiers = new List<float>(percentualModifiers);
            clone.linearModifiers = new List<float>(linearModifiers);

            return clone;
        }

        #region GET

        public float Get()
        {
            var value = baseStat;
            foreach (var item in linearModifiers)
                value += item;
            foreach (var item in percentualModifiers)
                value += item * value / 100;

            return value;
        }

        #endregion

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