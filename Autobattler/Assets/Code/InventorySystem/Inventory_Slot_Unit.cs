using System.Data;
using Autobattler.DragAndDrop;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.InventorySystem
{
    public class Inventory_Slot_Unit : DropArea
    {
        public Inventory_Units inventory;

        public void InyectDependencies(Canvas canvas, Inventory_Units inventory)
        {
            this.canvas = canvas;
            this.inventory = inventory;
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return draggable.item is UnitView;
        }

        protected override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);
            inventory.AttachUnit(GetUnitFromDraggable(draggable));
        }

        public override void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            draggable.onDropAction += MyItemHasDropSomewhere;
        }

        private void MyItemHasDropSomewhere(DropArea dropArea, DraggableComponent draggable)
        {
            if (dropArea is not Inventory_Slot_Unit)
            {
                inventory.UnattachUnit(GetUnitFromDraggable(draggable));
            }

            draggable.onDropAction -= MyItemHasDropSomewhere;
        }

        private _Unit GetUnitFromDraggable(DraggableComponent draggable)
        {
            return (draggable.item as UnitView).unit;
        }
    }
}
