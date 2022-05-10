using Auttobattler.Backend;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Auttobattler.Frontend
{
    class FighterView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Fighter CombatInstance { get => null; }

        private UnitInfoBars infoBars;
        private Image image;
        private Transform numberPopupsLocation;

        private AnimationsController animationsController;

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
