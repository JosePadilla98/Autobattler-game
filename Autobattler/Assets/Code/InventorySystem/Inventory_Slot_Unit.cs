using System.Data;
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

        public override void OnPlayerTakeAwayMyItem(GenericDragObject<UnitView> draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            draggable.onDropAction += MyItemHasDropSomewhere;
        }

        private void MyItemHasDropSomewhere(DropArea<UnitView> dropArea, GenericDragObject<UnitView> obj)
        {
            if (dropArea is not Inventory_Slot_Unit)
            {
                inventory.UnattachUnit(obj.item.unit);
            }

            obj.onDropAction -= MyItemHasDropSomewhere;
        }
    }
}
