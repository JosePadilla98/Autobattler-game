using Auttobattler.Mutators;
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
        public List<UnitMutator> mutators;

        public Unit(UnitBuild blueprint)
        {
            stats = new Stats(blueprint);
            mutators = new List<UnitMutator>(blueprint.mutators);
        }

        public object Clone()
        {
            var clone = (Unit)this.MemberwiseClone();
            return clone;
        }
    }
}
