using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Combat;

namespace Auttobattler
{
    [RequireComponent(typeof(UnitDragHandler))]
    public class PlayerUnit : Unit
    {
        
        private UnitDragHandler dragHandler;
        public BuildedUnitBlueprint blueprint;

        private void Awake()
        {
            dragHandler = GetComponent<UnitDragHandler>();
            dragHandler.dropArea.CombatSlot.unit = CombatInstance;

            CreateCombatInstance(new BuildedUnit(blueprint, blueprint.level), Side.LEFT);
        }
    }
}
