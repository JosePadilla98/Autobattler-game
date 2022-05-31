using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.SelectionSystem;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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