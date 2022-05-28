using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    public abstract class DropArea : MonoBehaviour, IDropHandler
    {
        public Canvas canvas;

        protected DraggableComponent draggableObj;

        private DraggableComponent objBeingDragged => ObjectBeingDragged.obj;

        /// <summary>
        /// Se llama sólo desde el awake del dragObject: Cuando la lógica instancia al item.
        /// </summary>
        /// <param name="draggableObj"></param>
        public void SetDraggableObj(DraggableComponent draggableObj)
        {
            this.draggableObj = draggableObj;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!CanThisObjectBeDroppedHere(objBeingDragged))
                return;

            if (!draggableObj)
            {
                Drop(objBeingDragged);
            }
            else
            {
                SwapPlaces(objBeingDragged);
            }
        }

        protected virtual bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return true;
        }

        private void SwapPlaces(DraggableComponent itemToSwap)
        {
            itemToSwap.lastDropArea.Drop(draggableObj);
            Drop(itemToSwap);
        }

        /// <summary>
        /// Se llama cuando el player se lleva el item con el mouse
        /// </summary>
        /// <param name="item"></param>
        public virtual void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            draggableObj = null;
        }

        /// <summary>
        /// Se llama sólo cuando el player dropea el item con el mouse
        /// </summary>
        /// <param name="draggable"></param>
        protected virtual void Drop(DraggableComponent draggable)
        {
            draggableObj = draggable;
            draggable.dropArea = this;

            Transform itemTransform = draggable.transform;
            itemTransform.SetParent(transform);
            itemTransform.position = transform.position;
            draggable.Rect.anchoredPosition = Vector3.zero;

            draggable.onDropAction?.Invoke(this, draggableObj);
        }
    }
}