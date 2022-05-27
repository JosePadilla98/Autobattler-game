using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    public class DropArea<T> : MonoBehaviour, IDropHandler
    {
        public Canvas canvas;

        private GenericDragObject<T> draggableObj;
        public GenericDragObject<T> DraggableObj
        {
            get => draggableObj;
            set
            {
                draggableObj = value;
                itemTransform = (draggableObj != null) ? draggableObj.transform : null;
            }
        }

        private Transform itemTransform;

        public void OnDrop(PointerEventData eventData)
        {
            if (!DraggableObj)
            {
                AttachItem(GenericDragObject<T>.objBeingDragged);
            }
            else
            {
                SwapPlaces(GenericDragObject<T>.objBeingDragged);
            }
        }

        private void AttachItem(GenericDragObject<T> item)
        {
            DraggableObj = item;
            DraggableObj.dropArea = this;
            itemTransform.SetParent(transform);
            itemTransform.position = transform.position;
            DraggableObj.Rect.anchoredPosition = Vector3.zero;
            OnItemDropped(DraggableObj.item);
        }

        private void SwapPlaces(GenericDragObject<T> itemToSwap)
        {
            itemToSwap.lastDropArea.AttachItem(DraggableObj);
            AttachItem(itemToSwap);
        }

        public virtual void OnItemDropped(T view)
        {

        }

        public virtual void OnItemUnnatached(T view)
        {

        }
    }
}