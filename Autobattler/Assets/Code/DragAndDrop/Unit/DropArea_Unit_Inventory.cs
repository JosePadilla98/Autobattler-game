using System;
using Autobattler.Grid.ManagementState;
using Autobattler.InventorySystem;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.DragAndDrop.Unit
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_Unit_Inventory : DropArea<UnitView>
    {
        public Inventory_Units inventory;

        private void Awake()
        {

        }

        public void InyectDependencies(Inventory_Units inventory)
        {
            this.inventory = inventory;
        }

        public override void OnItemDropped(UnitView item)
        {

        }

        internal override void UnattachItem()
        {

        }
    }
}
