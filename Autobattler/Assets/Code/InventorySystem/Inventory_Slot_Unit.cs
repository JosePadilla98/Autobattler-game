using System;
using Autobattler.Grid.ManagementState;
using Autobattler.InventorySystem;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.DragAndDrop.Unit
{
    public class Inventory_Slot_Unit : DropArea<UnitView>
    {
        public Inventory_Units inventory;

        private void Awake()
        {

        }

        public void InyectDependencies(Canvas canvas, Inventory_Units inventory)
        {
            this.canvas = canvas;
            this.inventory = inventory;
        }

        public override void OnItemDropped(UnitView view)
        {
            inventory.AttachUnit(view.unit);
        }
    }
}
