using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    public class DropArea<T> : MonoBehaviour, IDropHandler
    {
        private GenericDragObject<T> draggableComponent;
        public GenericDragObject<T> DraggableComponent
        {
            get => draggableComponent;
            set
            {
                draggableComponent = value;
                itemTransform = (draggableComponent != null) ? draggableComponent.transform : null;
            }
        }

        private Transform itemTransform;

        public void OnDrop(PointerEventData eventData)
        {
            if (!DraggableComponent)
            {
                DraggableComponent = GenericDragObject<T>.objBeingDragged;
                DraggableComponent.dropArea = this;
                itemTransform.SetParent(transform);
                itemTransform.position = transform.position;
                DraggableComponent.Rect.anchoredPosition = Vector3.zero;
                OnItemDropped(DraggableComponent.itemDragged);
            }
        }

        public virtual void OnItemDropped(T item)
        {

        }

        internal virtual void UnattachUnit()
        {
            
        }
    }
}