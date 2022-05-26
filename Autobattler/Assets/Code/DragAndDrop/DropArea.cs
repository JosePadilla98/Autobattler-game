using System;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    public class DropArea<T> : MonoBehaviour, IDropHandler
    {
        public Canvas canvas;

        private GenericDragObject<T> itemContained;
        public GenericDragObject<T> ItemContained
        {
            get => itemContained;
            set
            {
                itemContained = value;
                itemTransform = (itemContained != null) ? itemContained.transform : null;
            }
        }

        private Transform itemTransform;

        public void OnDrop(PointerEventData eventData)
        {
            if (!ItemContained)
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
            ItemContained = item;
            ItemContained.dropArea = this;
            itemTransform.SetParent(transform);
            itemTransform.position = transform.position;
            ItemContained.Rect.anchoredPosition = Vector3.zero;
            OnItemDropped(ItemContained.itemDragged);
        }

        private void SwapPlaces(GenericDragObject<T> itemToSwap)
        {
            itemToSwap.lastDropArea.AttachItem(ItemContained);
            AttachItem(itemToSwap);
        }

        public virtual void OnItemDropped(T item)
        {

        }

        internal virtual void UnattachItem()
        {
            
        }
    }
}