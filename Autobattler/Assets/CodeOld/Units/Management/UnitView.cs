using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AutobattlerOld.Units.Management
{
    public class UnitView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image image;
        public Unit unit;

        public UnityEvent<Unit> onPointerEnterEvent;
        public UnityEvent<Unit> onPointerExitEvent;

        private bool mouseIsOverMe;

        public void InyectDependences(Unit unit)
        {
            this.unit = unit;
            image.sprite = unit.sprite;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnterEvent?.Invoke(unit);
            mouseIsOverMe = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onPointerExitEvent?.Invoke(unit);
            mouseIsOverMe = false;
        }

        private void OnEnable()
        {
            if (unit != null)
                image.sprite = unit.sprite;
        }

        private void OnDisable()
        {
            if (!mouseIsOverMe)
                return;

            onPointerExitEvent.Invoke(unit);
            mouseIsOverMe = false;
        }

        public void Refresh()
        {
            image.sprite = unit.sprite;
        }
    }
}