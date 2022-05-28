using System;
using Autobattler.Grid.ManagementState;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.DragAndDrop.Unit
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_Unit : DropArea
    {
        private Slot_U_View slotView;

        private void Awake()
        {
            slotView = GetComponent<Slot_U_View>();
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return draggable.item is UnitView;
        }

        protected override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);
            slotView.AttachUnit(draggable.item as UnitView); 
        }

        public override void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            slotView.UnattachUnit(draggable.item as UnitView);
        }
    }
}
