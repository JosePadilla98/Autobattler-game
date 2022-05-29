using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Units.Management
{
    public class UnitView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image image;
        public Unit unit;

        public UnityEvent<Unit> onPointerEnterEvent;
        public UnityEvent<Unit> onPointerExitEvent;

        public void InyectDependences(Unit unit, Canvas canvas)
        {
            this.unit = unit;
            image.sprite = unit.sprite;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnterEvent.Invoke(unit);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onPointerExitEvent.Invoke(unit);
        }

    }
}