using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace auttobattler
{
    public class CreatureDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Canvas canvas;
        private RectTransform rect;

        public static CreatureDragHandler objBeingDraged;

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;

        private BattlefieldSlot lastSlot;
        public BattlefieldSlot slot;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            slot = transform.parent.GetComponent<BattlefieldSlot>();
            slot.item = this;
        }

        private void Start()
        {
            canvas = CanvasSingleton.Instance;
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            objBeingDraged = this;

            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(canvas.transform);

            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            lastSlot = slot;
            slot.item = null;
            slot = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            objBeingDraged = null;
            if (transform.parent == canvas.transform)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);

                slot = lastSlot;
            }
        }

        #endregion
    }
}
