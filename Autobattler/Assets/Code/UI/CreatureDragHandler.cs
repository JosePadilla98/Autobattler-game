using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    [RequireComponent(typeof(CreatureCombatUI))]
    public class CreatureDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Canvas canvas;
        private RectTransform rect;

        public static CreatureDragHandler objBeingDraged;

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;

        [HideInInspector]
        public GridDropArea slot;
        private GridDropArea lastSlot;

        private CreatureCombatUI creatureUI;
        public CreatureCombatUI CreatureUI { get => creatureUI; }
        public Transform Limbo { get => Battlefield.Instance.transform; }

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            creatureUI = GetComponent<CreatureCombatUI>();

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
            transform.SetParent(Limbo);

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
            if (transform.parent == Limbo)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);

                slot = lastSlot;
            }
        }

        #endregion
    }
}
