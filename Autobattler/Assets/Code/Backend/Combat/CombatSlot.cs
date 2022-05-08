using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;
using System;

namespace Auttobattler
{
    public class CombatSlot 
    {
        private Grid parent;
        private Fighter unit;
        public Action<Fighter> OnUnitAttached;
        public Action OnUnitUnattached;
        public Side Side { get => parent.side; }
        public Fighter Unit { get => unit; }

        public CombatSlot(Grid parent)
        {
            this.parent = parent;
        }

        public bool IsThereThisCreature(Fighter creature)
        {
            if (creature == null) 
                return false;

            return (this.unit == creature);
        }

        public void AttachUnit(Fighter unit)
        {
            this.unit = unit;
            OnUnitAttached(unit);
        }
    }
}
