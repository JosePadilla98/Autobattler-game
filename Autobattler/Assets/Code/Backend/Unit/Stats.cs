using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Mutators;
using Auttobattler.Ultimates;
using System;

namespace Auttobattler
{
    public enum StatsNames
    {
        HEALTH, HEALTH_REGEN,
        PHYSICAL_ATTACK, MAGICAL_ATTACK,
        PHYSICAL_DEFENSE, MAGICAL_DEFENSE,
        SPEED, MAGICAL_CHARGE_VELOCITY,
        VIGOR, REINVIGORATION,
        MAX_MANA, MANA_REGEN,
        INTELLECT,

        WEIGHT_CAPACITY,

        PHYSICAL_FATIGUE, MAGICAL_FATIGUE,
        BASE_ATTACK_DURATION
    }

    public class Stats
    {
        private static Dictionary<StatsNames, Stat> StandardStats()
        {
            Dictionary<StatsNames, Stat> dic = new Dictionary<StatsNames, Stat>
            {
                { StatsNames.HEALTH, new Stat(25f) },
                { StatsNames.HEALTH_REGEN, new Stat(0.05f) },

                { StatsNames.PHYSICAL_ATTACK, new Stat(25f, true) },
                { StatsNames.MAGICAL_ATTACK, new Stat(25f, true) },

                { StatsNames.PHYSICAL_DEFENSE, new Stat(25f, true) },
                { StatsNames.MAGICAL_DEFENSE, new Stat(25f, true) },

                { StatsNames.SPEED, new Stat(25f) },
                { StatsNames.MAGICAL_CHARGE_VELOCITY, new Stat(25f) },

                { StatsNames.VIGOR, new Stat(100f) },
                { StatsNames.REINVIGORATION, new Stat(1f) },

                { StatsNames.MAX_MANA, new Stat(100f) },
                { StatsNames.MANA_REGEN, new Stat(1f) },

                { StatsNames.INTELLECT, new Stat(25f) },

                { StatsNames.WEIGHT_CAPACITY, new Stat(10f) },

                { StatsNames.PHYSICAL_FATIGUE, new Stat(1f) },
                { StatsNames.MAGICAL_FATIGUE, new Stat(1f) },

                { StatsNames.BASE_ATTACK_DURATION, new Stat(100f) },
            };


            return dic;
        }

        public Stats()
        {

        }



        public float GetValue(StatsNames name, int level)
        {
            //Se le aplica el nivelsi lo requiere
            return dic
        }
    }

    public class Stat : ICloneable
    {
        private float baseStat;
        public List<float> modifiers = new List<float>();
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

                foreach (var item in modifiers)
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
            clone.modifiers = new List<float>(modifiers);
            clone.linearModifiers = new List<float>(linearModifiers);

            return clone;
        }
    }

}


