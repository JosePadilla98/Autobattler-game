using Autobattler.InfoPanel;
using Autobattler.Units.InfoBars;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Units
{
    internal class FighterView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private AnimationsController animationsController;
        private Image image;

        private UnitInfoBars infoBars;
        private Transform numberPopupsLocation;
        public Fighter CombatInstance => null;

        #region MOUSE_INTERACTIONS

        public void OnPointerEnter(PointerEventData eventData)
        {
            //UnitInfoPanel.Instance?.AttachUnit(comb);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //UnitInfoPanel.Instance?.Unattach();
        }

        #endregion
    }
}