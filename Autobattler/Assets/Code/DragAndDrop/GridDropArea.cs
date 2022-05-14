using Autobattler.Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.Grid
{
    public class GridDropArea<T> : MonoBehaviour, IDropHandler
    {
        [HideInInspector] 
        public UnitDragHandler item;

        public T SlotView { get; private set; }

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                item = UnitDragHandler.objBeingDraged;
                //item.dropArea = this;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                item.Rect.anchoredPosition = Vector3.zero;
            }
        }

        private void Awake()
        {
            SlotView = GetComponent<T>();
        }
    }
}