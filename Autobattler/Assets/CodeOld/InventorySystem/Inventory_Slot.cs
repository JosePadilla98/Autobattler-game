using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.InventorySystem
{
    public class Inventory_Slot : DropArea
    {
        public Inventory inventory;
        public bool HasItem => transform.childCount > 0;

        public void InyectDependencies(Canvas canvas, Inventory inventory)
        {
            this.canvas = canvas;
            this.inventory = inventory;
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return (draggable.item is UnitView or ItemView);
        }

        public override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);

            switch (draggable.item)
            {
                case UnitView unitView:
                    inventory.CheckIfAttachUnit(unitView.unit);
                    break;

                case ItemView itemView:
                    inventory.CheckIfAttachItem(itemView.item);
                    break;
            }
        }
        protected override void MyLastItemHasBeenPlacedSomewhere(DropArea dropAreaWherePlaced, DraggableComponent draggable)
        {
            base.MyLastItemHasBeenPlacedSomewhere(dropAreaWherePlaced, draggable);

            if (dropAreaWherePlaced is Inventory_Slot)
                return;

            switch (draggable.item)
            {
                case UnitView unitView:
                    inventory.UnattachUnit(unitView.unit);
                    break;

                case ItemView itemView:
                    inventory.UnattachItem(itemView.item);
                    break;
            }
        }
    }
}
