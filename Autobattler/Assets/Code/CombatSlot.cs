using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class CombatSlot : MonoBehaviour
    {
        public CreatureInCombat creature;

        public bool IsThereThisCreature(CreatureInCombat creature)
        {
            if (creature == null) 
                return false;

            return (this.creature == creature);
        }
    }
}
