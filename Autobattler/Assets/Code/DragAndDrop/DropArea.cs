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
        /// Se llama sólo desde el awake del draggableObj: Cuando la lógica lo instancia
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
                CheckIfSwapPlaces(draggableObj, objBeingDragged);
            }
        }

        protected virtual bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return true;
        }

        private void CheckIfSwapPlaces(DraggableComponent itemContainedHere, DraggableComponent itemToSwap)
        {
            var slotToMaybeGo = itemToSwap.lastDropArea;
            if (!slotToMaybeGo.CanThisObjectBeDroppedHere(itemContainedHere))
                return;

            SwapPlaces(itemToSwap);
        }

        private void SwapPlaces(DraggableComponent itemToSwap)
        {
            var itemWhoWhasHere = draggableObj;
            var newAreaForOldItem = itemToSwap.lastDropArea;

            OnPlayerTakeAwayMyItem(itemWhoWhasHere);
            Drop(itemToSwap);

            newAreaForOldItem.Drop(itemWhoWhasHere);
        }

        /// <summary>
        /// Se llama cuando el player se lleva el item con el mouse
        /// </summary>
        /// <param name="item"></param>
        public virtual void OnPlayerTakeAwayMyItem(DraggableComponent draggable)
        {
            draggableObj = null;

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.dragAndDrop.units)
                Debug.Log(draggable.name + " take away from (" + name + ")");

            #endif
        }

        /// <summary>
        /// Se llama sólo cuando el player dropea el item con el mouse o cuando vuelve por no haber sido arrastrado a ningún sitio
        /// </summary>
        /// <param name="draggable"></param>
        public virtual void Drop(DraggableComponent draggable)
        {
            draggableObj = draggable;
            draggable.dropArea = this;

            Transform itemTransform = draggable.transform;
            itemTransform.SetParent(transform);
            itemTransform.position = transform.position;
            draggable.Rect.anchoredPosition = Vector3.zero;

            draggable.onDropAction?.Invoke(this, draggableObj);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.dragAndDrop.units)
                Debug.Log(draggable.name + " dropped in (" + name + ")");

            #endif
        }
    }
}