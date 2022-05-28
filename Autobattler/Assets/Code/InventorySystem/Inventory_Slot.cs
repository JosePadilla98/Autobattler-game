using System.Data;
using Autobattler.DragAndDrop;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.InventorySystem
{
    public class Inventory_Slot : DropArea
    {
        public Inventory inventory;

        public void InyectDependencies(Canvas canvas, Inventory inventory)
        {
            this.canvas = canvas;
            this.inventory = inventory;
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return (draggable.item is UnitView or Item);
        }

        protected override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);

            if (draggable.item is UnitView unitView)
            {
                inventory.AttachUnit(unitView.unit);
            }

            if (draggable.item is Item item)
            {
                inventory.AttachItem(item);
            }
        }

        public override void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            draggable.onDropAction += MyItemHasDropSomewhere;
        }

        private void MyItemHasDropSomewhere(DropArea dropArea, DraggableComponent draggable)
        {
            if (dropArea is not Inventory_Slot)
            {

                if (draggable.item is UnitView unitView)
                {
                    inventory.UnattachUnit(unitView.unit);
                }

                if (draggable.item is Item item)
                {
                    inventory.UnattachItem(item);
                }
            }

            draggable.onDropAction -= MyItemHasDropSomewhere;
        }
    }
}
