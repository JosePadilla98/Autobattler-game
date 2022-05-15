using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Units
{
    public class UnitView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image image;
        private Unit unit;

        public UnityEvent<Unit> onPointerEnterEvent;
        public UnityEvent<Unit> onPointerExitEvent;

        public Canvas canvas { get; private set; }

        public void InyectDependences(Unit unit, Canvas canvas)
        {
            this.unit = unit;
            this.canvas = canvas;
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