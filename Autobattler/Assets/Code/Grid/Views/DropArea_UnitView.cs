using Autobattler.DragAndDrop;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.Grid.Views
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_UnitView : DropArea
    {
        [Space(20)]
        [SerializeField]
        private UnityEvent<UnitView> onItemDropped;
        [Space(20)]
        [SerializeField]
        private UnityEvent<UnitView> onItemTaken;

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return draggable.item is UnitView;
        }

        public override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);
            var unitView = draggable.item as UnitView;
            onItemDropped.Invoke(unitView);
        }

        public override void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            base.OnPlayerTakeAwayMyItem(draggable);
            var unitView = draggable.item as UnitView;
            onItemTaken.Invoke(unitView);

            
        }
    }
}
