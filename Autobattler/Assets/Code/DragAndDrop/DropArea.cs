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
            if (!item)
            {
                item = GenericDragObject<T>.objBeingDragged;
                item.dropArea = this;
                itemTransform.SetParent(transform);
                itemTransform.position = transform.position;
                item.Rect.anchoredPosition = Vector3.zero;
            }
        }
    }
}