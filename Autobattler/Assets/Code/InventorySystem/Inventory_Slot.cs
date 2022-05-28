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

        public override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);

            switch (draggable.item)
            {
                case UnitView unitView:
                    inventory.CheckIfAttachUnit(unitView.unit);
                    break;

                case Item item:
                    inventory.CheckIfAttachItem(item);
                    break;
            }
        }

        public override void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            draggable.onDropAction += MyItemHasDropSomewhere;
        }

        private void MyItemHasDropSomewhere(DropArea dropArea, DraggableComponent draggable)
        {
            draggable.onDropAction -= MyItemHasDropSomewhere;

            if (dropArea is Inventory_Slot)
                return;

            switch (draggable.item)
            {
                case UnitView unitView:
                    inventory.UnattachUnit(unitView.unit);
                    break;

                case Item item:
                    inventory.UnattachItem(item);
                    break;
            }
        }
    }
}
