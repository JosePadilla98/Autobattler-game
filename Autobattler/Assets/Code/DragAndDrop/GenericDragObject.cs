using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class GenericDragObject<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GenericDragObject<T> objBeingDragged;

        private CanvasGroup canvasGroup;
        private DropArea<T> lastDropArea;
        private Transform myTransform;
        private Transform startParent;
        private Vector3 startPosition;

        [HideInInspector]
        public DropArea<T> dropArea;
        public RectTransform Rect { get; private set; }

        public T itemDragged;

        protected virtual void Awake()
        {
            Rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            myTransform = transform;
            dropArea = myTransform.parent.GetComponent<DropArea<T>>();
            dropArea.DraggableComponent = this;
            itemDragged = GetComponent<T>();
        }

        protected abstract Transform ParentWhileDragging();

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            objBeingDragged = this;
            startPosition = myTransform.position;
            startParent = myTransform.parent;
            myTransform.SetParent(ParentWhileDragging());

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            lastDropArea = dropArea;
            dropArea.DraggableComponent = null;
            dropArea = null;

            lastDropArea.UnattachUnit();
        }

        public abstract void OnDrag(PointerEventData eventData);

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            objBeingDragged = null;
            if (myTransform.parent == ParentWhileDragging())
            {
                myTransform.position = startPosition;
                myTransform.SetParent(startParent);

                dropArea = lastDropArea;
            }
        }

        #endregion
    }
}