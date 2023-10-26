using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace AutobattlerOld.Grid.Views
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_UnitView : DropArea
    {
        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return draggable.item is UnitView;
        }
    }
}
