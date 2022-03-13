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
        public BuildedUnitBlueprint blueprint;
        private UnitDragHandler dragHandler;

        public void PreparativesToBattle()
        {
            CreateCombatInstance(new BuildedUnit(blueprint));
            dragHandler.dropArea.CombatSlot.unit = combatModule;
        }

        private void Awake()
        {
            dragHandler = GetComponent<UnitDragHandler>();
        }
    }
}
