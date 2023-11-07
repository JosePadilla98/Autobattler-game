using System;
using System.Collections.Generic;
using AutobattlerOld.MutationsSystem.Mutations;
using AutobattlerOld.Units.Combat;
using UnityEngine;

namespace AutobattlerOld.Units.Management
{
    public class Unit : ICloneable
    {
        public String name;
        public Sprite sprite;
        public StatsContainer statsContainer;

        public Unit() { }

        public Unit(UnitBuild blueprint)
        {
            UnitInitialization(blueprint);
        }

        protected void UnitInitialization(UnitBuild blueprint)
        {
            statsContainer = new StatsContainer();

            name = blueprint.buildName;
            sprite = blueprint.sprite;
        }

        public object Clone()
        {
            var clone = (Unit)MemberwiseClone();
            return clone;
        }

        public Fighter BuildCombatInstance()
        {
            return new Fighter(this);
        }
    }
}
