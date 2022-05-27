using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.DragAndDrop
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class GenericDragObject<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GenericDragObject<T> objBeingDragged;

        private CanvasGroup canvasGroup;
        private Transform myTransform;
        private Transform startParent;
        private Vector3 startPosition;
        public Canvas canvas;

        [HideInInspector]
        public DropArea<T> dropArea;
        [HideInInspector]
        public DropArea<T> lastDropArea;
        public RectTransform Rect { get; private set; }
      
        public Transform ParentWhileDragging { get => canvas.transform; }

        public T item;

        protected virtual void Awake()
        {
            Rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            myTransform = transform;
            dropArea = myTransform.parent.GetComponent<DropArea<T>>();
            dropArea.SetDraggableObj(this);
            canvas = dropArea.canvas;
            item = GetComponent<T>();
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            objBeingDragged = this;
            startPosition = myTransform.position;
            startParent = myTransform.parent;
            myTransform.SetParent(ParentWhileDragging);

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            lastDropArea = dropArea;
            dropArea.OnPlayerTakeAwayItem(item);
            dropArea = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            objBeingDragged = null;

            if (myTransform.parent == ParentWhileDragging)
            {   
                //This represent that element is not dropped anywhere
                myTransform.position = startPosition;
                myTransform.SetParent(startParent);
                dropArea = lastDropArea;
            }
        }

        #endregion
    }
}