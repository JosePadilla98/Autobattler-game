using System;
using Autobattler.Grid.ManagementState;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.DragAndDrop.Unit
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_Unit : DropArea<UnitView>
    {
        private Slot_U_View slotView;

        private void Awake()
        {
            slotView = GetComponent<Slot_U_View>();
        }

        public override void OnItemDropped(UnitView view)
        {
            base.OnItemDropped(view);
            slotView.AttachUnit(view);
        }

        public override void OnPlayerTakeAwayMyItem(GenericDragObject<UnitView> draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            slotView.UnattachUnit(draggable.item);
        }
    }
}
