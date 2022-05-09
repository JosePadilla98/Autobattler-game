using Assets.Code.Frontend.UnitView.Unit.Components;
using Assets.Code.Frontend.UnitView.Unit.Components.InfoBars;
using Auttobattler.Backend.RunLogic.Combat;
using Auttobattler.Frontend;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Code.Frontend.Run.Views.Unit.Shapes
{
    class UnitCombatShape : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
