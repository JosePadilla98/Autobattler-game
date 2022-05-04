using Auttobattler.MutationsSystem;
using Auttobattler.Scriptables;
using Auttobattler.Ultimates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class Unit : ICloneable
    {
        public Stats stats;

        public List<Mutation> mutations;
        public List<Mutation> disabledMutations;

        public Unit(UnitBuild blueprint)
        {
            stats = new Stats();
            mutations = new List<Mutation>(blueprint.mutations);
            disabledMutations = new List<Mutation>();
        }
        
        public object Clone()
        {
            var clone = (Unit)this.MemberwiseClone();
            return clone;
        }
    }
}
