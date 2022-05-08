using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler.Frontend.ManagementState
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UnitDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rect;
        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        public static UnitDragHandler objBeingDraged;

        [HideInInspector]
        public PlayerGridSlot dropArea;
        private PlayerGridSlot lastDropArea;

        public Transform TmpParent { get => CanvasSingleton.Instance.transform; }
        public RectTransform Rect { get => rect;  }

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            dropArea = transform.parent.GetComponent<PlayerGridSlot>();
            dropArea.item = this;
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            objBeingDraged = this;
            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(TmpParent);

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            lastDropArea = dropArea;
            dropArea.item = null;
            dropArea = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Rect.anchoredPosition += eventData.delta / CanvasSingleton.Instance.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            objBeingDraged = null;
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
