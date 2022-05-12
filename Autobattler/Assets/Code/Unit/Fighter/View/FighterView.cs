using Autobattler.InfoPanel;
using Autobattler.Unit.Fighter.View.InfoBars;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Unit.Fighter.View
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
            UnitInfoPanel.Instance?.AttachUnit(CombatInstance);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UnitInfoPanel.Instance?.UnattachUnit();
        }

        #endregion
    }
}