using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.Unit.Unit.View
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UnitDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static UnitDragHandler objBeingDraged;
        private CanvasGroup canvasGroup;

        [HideInInspector] public PlayerGridSlot dropArea;

        private PlayerGridSlot lastDropArea;
        private Transform startParent;
        private Vector3 startPosition;

        public Transform TmpParent => null;
        public RectTransform Rect { get; private set; }

        private void Awake()
        {
            Rect = GetComponent<RectTransform>();
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
            //Rect.anchoredPosition += eventData.delta / CanvasSingleton.Instance.scaleFactor;
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