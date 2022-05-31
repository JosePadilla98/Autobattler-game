using Autobattler.DragAndDrop;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public class UnitsList_Slot : DropArea
    {
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