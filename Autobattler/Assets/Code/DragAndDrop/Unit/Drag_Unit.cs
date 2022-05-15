using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    [RequireComponent(typeof(UnitView))]
    public class Drag_Unit : GenericDragObject<Unit>
    {
        private UnitView unitView;
        private Canvas Canvas { get => unitView.canvas;}

        private void Awake()
        {
            base.Awake();
            unitView = GetComponent<UnitView>();
        }

        public override void OnDrag(PointerEventData eventData)
        {
            Rect.anchoredPosition += eventData.delta / Canvas.scaleFactor;
        }
    }
}