using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;
using System;

namespace Auttobattler.Ultimates
{
    public abstract class UltimateScriptable : ScriptableObject
    {
        [Range(1, 400)]
        public int cost;
        public abstract Ultimate GetUltimate();
    }

    public abstract class Ultimate
    {
        public abstract string GetName();
        public abstract void Cast(UnitCombatInstance instance);
    }

    [System.Serializable]
    public class AttackData : ICloneable
    {
        public float Power;
        public AttackType type;
        public float EncumbranceMultiplier;
        public float manaCost;

        public object Clone()
        {
            var clone = (AttackData)this.MemberwiseClone();
            return clone;
        }
    }
}