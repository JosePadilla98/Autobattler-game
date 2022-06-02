using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Autobattler.DragAndDrop
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DraggableComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDragAndDropEvent
    {
        private CanvasGroup canvasGroup;
        private Transform myTransform;
        private Transform startParent;
        private Vector3 startPosition;
        private Canvas canvas;

        [HideInInspector]
        public DropArea dropArea;
        [HideInInspector]
        public DropArea lastDropArea;
        public RectTransform Rect { get; private set; }
        public Transform ParentWhileDragging { get => canvas.transform; }

        public Action<DropArea, DraggableComponent> onDropAction;

        public DraggableComponent ObjBeingDragged
        {
            get => ObjectBeingDragged.obj;
            private set => ObjectBeingDragged.obj = value;
        }

        public MonoBehaviour item;

        protected virtual void Awake()
        {
            Rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            myTransform = transform;
            dropArea = myTransform.parent.GetComponent<DropArea>();
            dropArea.SetDraggableObj(this);
            canvas = dropArea.canvas;
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            ObjBeingDragged = this;
            startPosition = myTransform.position;
            startParent = myTransform.parent;
            myTransform.SetParent(ParentWhileDragging);

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            lastDropArea = dropArea;
            dropArea.OnPlayerTakeAwayMyItem(this);
            dropArea = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        /// <summary>
        /// Se llama antes del OnDrop de DropArea
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            EndDrag();
        }

        public void EndDrag()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            ObjBeingDragged = null;

            if (myTransform.parent == ParentWhileDragging)
            {
                //This represent that element is not dropped anywhere
                myTransform.position = startPosition;
                myTransform.SetParent(startParent);
                dropArea = lastDropArea;
                dropArea.Drop(this);
            }
        }

        #endregion
    }
}