using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop.Unit
{
    [RequireComponent(typeof(UnitView))]
    public class Drag_UnitView : GenericDragObject<UnitView>
    {
        private Canvas Canvas { get => itemDragged.canvas;}

        public override void OnDrag(PointerEventData eventData)
        {
            Rect.anchoredPosition += eventData.delta / Canvas.scaleFactor;
        }

        protected override Transform ParentWhileDragging()
        {
            return Canvas.transform;
        }
    }
}