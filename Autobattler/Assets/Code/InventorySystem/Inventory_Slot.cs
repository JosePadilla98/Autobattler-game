using System.Data;
using Autobattler.DragAndDrop;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.InventorySystem
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

                case ItemView itemView:
                    inventory.UnattachItem(itemView.item);
                    break;
            }
        }
    }
}
