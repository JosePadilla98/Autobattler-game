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
        private Transform startParent;
        private Vector3 startPosition;

        [HideInInspector]
        public DropArea<T> dropArea;
        public Transform TmpParent => null;
        public RectTransform Rect { get; private set; }

        private void Awake()
        {
            Rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            dropArea = transform.parent.GetComponent<DropArea<T>>();
            dropArea.Item = this;
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            objBeingDragged = this;
            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(TmpParent);

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            lastDropArea = dropArea;
            dropArea.Item = null;
            dropArea = null;
        }

        public abstract void OnDrag(PointerEventData eventData);

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            objBeingDragged = null;
            if (transform.parent == TmpParent)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);

                dropArea = lastDropArea;
            }
        }

        #endregion
    }
}