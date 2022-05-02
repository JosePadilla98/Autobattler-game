using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Combat;

namespace Auttobattler
{
    [RequireComponent(typeof(UnitDragHandler))]
    public class PlayerUnit : UnitRepresentation
    {
        private UnitDragHandler dragHandler;
        public UnitBuild blueprint;

        private void Start()
        {
            UnitCombatInstance combatInstance = new UnitCombatInstance(new Unit(blueprint), Side.LEFT);
            AttachCombatInstance(combatInstance);
            dragHandler = GetComponent<UnitDragHandler>();
            dragHandler.dropArea.CombatSlot.unit = CombatInstance;
        }
    }
}
