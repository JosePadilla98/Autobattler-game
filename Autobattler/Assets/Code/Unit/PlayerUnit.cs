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

        protected override void Awake()
        {
            base.Awake();

            CreateCombatInstance(new BuildedUnit(blueprint), Side.LEFT);
            dragHandler = GetComponent<UnitDragHandler>();
        }

        private void Start()
        {
            dragHandler.dropArea.CombatSlot.unit = CombatInstance;
        }
    }
}
