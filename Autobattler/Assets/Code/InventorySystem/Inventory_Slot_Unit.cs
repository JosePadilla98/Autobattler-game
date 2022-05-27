using Autobattler.DragAndDrop;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.InventorySystem
{
    public class Inventory_Slot_Unit : DropArea<UnitView>
    {
        public Inventory_Units inventory;

        public void InyectDependencies(Canvas canvas, Inventory_Units inventory)
        {
            this.canvas = canvas;
            this.inventory = inventory;
        }

        public override void OnItemDropped(UnitView view)
        {
            base.OnItemDropped(view);
            inventory.AttachUnit(view.unit);
        }

        public override void OnPlayerTakeAwayItem(UnitView view)
        {
            base.OnPlayerTakeAwayItem(view);
            inventory.UnattachUnit(view.unit);
        }
    }
}
