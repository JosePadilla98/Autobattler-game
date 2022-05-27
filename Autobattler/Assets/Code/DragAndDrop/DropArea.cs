using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    public abstract class DropArea<T> : MonoBehaviour, IDropHandler
    {
        public Canvas canvas;

        protected GenericDragObject<T> draggableObj;

        /// <summary>
        /// Se llama sólo desde el awake del dragObject: Cuando la lógica instancia al item.
        /// </summary>
        /// <param name="draggableObj"></param>
        public void SetDraggableObj(GenericDragObject<T> draggableObj)
        {
            this.draggableObj = draggableObj;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!draggableObj)
            {
                Drop(GenericDragObject<T>.objBeingDragged);
            }
            else
            {
                SwapPlaces(GenericDragObject<T>.objBeingDragged);
            }
        }

        /// <summary>
        /// Se llama sólo cuando el player dropea el item con el mouse
        /// </summary>
        /// <param name="item"></param>
        private void Drop(GenericDragObject<T> item)
        {
            draggableObj = item;
            draggableObj.dropArea = this;

            Transform itemTransform = draggableObj.transform;
            itemTransform.SetParent(transform);
            itemTransform.position = transform.position;
            draggableObj.Rect.anchoredPosition = Vector3.zero;

            draggableObj.onDropAction?.Invoke(this, draggableObj);
            OnItemDropped(draggableObj.item);
        }

        private void SwapPlaces(GenericDragObject<T> itemToSwap)
        {
            itemToSwap.lastDropArea.Drop(draggableObj);
            Drop(itemToSwap);
        }

        public virtual void OnItemDropped(T view)
        {

        }

        /// <summary>
        /// Se llama cuando el player se lleva el item con el mouse
        /// </summary>
        /// <param name="item"></param>
        public virtual void OnPlayerTakeAwayMyItem(GenericDragObject<T> draggable)
        {
            draggableObj = null;
        }
    }
}