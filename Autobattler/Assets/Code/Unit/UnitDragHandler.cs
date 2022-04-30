using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler
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
        public GridDropArea dropArea;
        private GridDropArea lastDropArea;

        //If animator is active while dragging, the position of this object goes to the shit
        private Animator animator; 
        
        public Transform TmpParent { get => CanvasSingleton.Instance.transform; }
        public RectTransform Rect { get => rect;  }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            dropArea = transform.parent.GetComponent<GridDropArea>();
            dropArea.item = this;
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(animator != null){
                animator.enabled = false;
            }

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
            if (animator != null)
                animator.enabled = true;

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
