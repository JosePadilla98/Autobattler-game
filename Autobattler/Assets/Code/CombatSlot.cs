using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class CombatSlot : MonoBehaviour
    {
        public UnitCombatModule unit;

        public bool IsThereThisCreature(UnitCombatModule creature)
        {
            if (creature == null) 
                return false;

            return (this.unit == creature);
        }
    }
}
