using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.UnitsListScreen
{
    public class UnitsList_Slot : DropArea
    {
        public Unit Unit => (draggableObj.item as UnitView).unit;

        public void InyectDependencies(Canvas canvas)
        {
            this.canvas = canvas;
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return draggable.item is UnitView;
        }
    }
}