using Auttobattler.Frontend;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Frontend.Run.Views.Grid
{
    public class GridDropArea<T> : MonoBehaviour, IDropHandler
    {
        [HideInInspector]
        public UnitDragHandler item;
        private T slotView;
        public T SlotView { get => slotView; }

        private void Awake()
        {
            slotView = GetComponent<T>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                item = UnitDragHandler.objBeingDraged;
                item.dropArea = this;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                item.Rect.anchoredPosition = Vector3.zero;
            }
        }
    }
}
