using Autobattler.DragAndDrop;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Grid.Views
{
    [RequireComponent(typeof(Slot_U_View))]
    public class Slot_U_DropArea : DropArea
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

        public override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);
            var unitView = draggable.item as UnitView;
            slotView.AttachUnit(unitView);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if(App.DebugController != null && App.DebugController.dragAndDrop.unitsInGrid)
                Debug.Log(unitView.unit.name + " dropped in (" + slotView.name + ") battlefield slot");

            #endif
        }

        public override void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            var unitView = draggable.item as UnitView;
            slotView.UnattachUnit(unitView);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.dragAndDrop.unitsInGrid)
                Debug.Log(unitView.unit.name + " take away from (" + slotView.name + ") battlefield slot");

            #endif
        }
    }
}
