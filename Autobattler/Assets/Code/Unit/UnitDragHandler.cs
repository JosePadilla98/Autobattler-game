using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    public class UnitDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Canvas canvas;
        private RectTransform rect;

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        public static UnitDragHandler objBeingDraged;

        [HideInInspector]
        public GridDropArea slot;
        private GridDropArea lastSlot;
        
        private Unit unit;
        public Unit Unit { get => unit; }
        public Transform TmpParent { get => Battlefield.Instance.transform; }

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            unit = GetComponent<Unit>();

            slot = transform.parent.GetComponent<GridDropArea>();
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
            transform.SetParent(TmpParent);

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
            if (transform.parent == TmpParent)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);

                slot = lastSlot;
            }
        }
        #endregion
    }
}
