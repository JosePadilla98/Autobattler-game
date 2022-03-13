using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class CombatSlot : MonoBehaviour
    {
        public UnitCombatInstance unit;

        public bool IsThereThisCreature(UnitCombatInstance creature)
        {
            if (creature == null) 
                return false;

            return (this.unit == creature);
        }
    }
}
