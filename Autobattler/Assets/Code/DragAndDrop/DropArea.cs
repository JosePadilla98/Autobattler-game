using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    public class DropArea<T> : MonoBehaviour, IDropHandler
    {
        private GenericDragObject<T> item;
        public GenericDragObject<T> Item
        {
            get => item;
            set
            {
                item = value;
                itemTransform = (item != null) ? item.transform : null;
            }
        }

        private Transform itemTransform;

        public void OnDrop(PointerEventData eventData)
        {
            if (!Item)
            {
                Item = GenericDragObject<T>.objBeingDragged;
                Item.dropArea = this;
                itemTransform.SetParent(transform);
                itemTransform.position = transform.position;
                Item.Rect.anchoredPosition = Vector3.zero;
            }
        }
    }
}