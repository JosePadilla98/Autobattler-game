using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    [RequireComponent(typeof(UnitView))]
    public class Drag_Unit : GenericDragObject<Unit>
    {
        private Canvas canvas;

        private void Awake()
        {
            canvas = GetComponent<UnitView>().canvas;
        }

        public override void OnDrag(PointerEventData eventData)
        {
            Rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}