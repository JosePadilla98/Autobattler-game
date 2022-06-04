using Autobattler.Units.Combat.View.InfoBars;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Units.Combat.View
{
    public class FighterView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image image;
        [SerializeField]
        private Transform numberPopupsLocation;
        [SerializeField]
        private AnimationsController animationsController;

        [Space(10)]
        [SerializeField]
        private UnitInfoBars infoBars;

        [Space(10)]
        public UnityEvent<Fighter> onPointerEnterEvent;
        public UnityEvent<Fighter> onPointerExitEvent;

        private Fighter fighter;

        public void InyectDependences(Fighter fighter)
        {
            this.fighter = fighter;
            image.sprite = fighter.Sprite;
        }

        #region MOUSE_INTERACTIONS

        public void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnterEvent.Invoke(fighter);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onPointerExitEvent.Invoke(fighter);
        }

        #endregion

    }
}