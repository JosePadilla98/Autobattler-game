using System;
using Autobattler.InfoPanel;
using Autobattler.Units.InfoBars;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Units
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