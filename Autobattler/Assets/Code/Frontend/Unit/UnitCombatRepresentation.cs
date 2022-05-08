using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    /// <summary>
    /// Represents a enemy unit ready to fight; in the pre-combat phase.
    /// Also represents a unit (enemy or player), fighting.
    /// </summary>
    public class FighterRepresentation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public UnitInfoBars infoBars;
        public Image image;
        public Transform numberPopupsLocation;

        private UnitAnimationsController animationsController;
        private Fighter combatInstance;

        public Fighter CombatInstance { get => combatInstance; }

        protected virtual void Awake()
        {
            animationsController = GetComponent<UnitAnimationsController>();
        }

        public void AttachCombatInstance(Fighter combatInstance)
        {
            this.combatInstance = combatInstance;
            infoBars.AttachUnit(CombatInstance);
        }

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

    [System.Serializable]
    public class UnitInfoBars
    {
        [SerializeField]
        private SliderBar healthBar;

        public void AttachUnit(Fighter unit)
        {
            healthBar.AttachMaxValue(unit.Stats.GetStat(StatsNames.HEALTH));
            healthBar.AttachValue(unit.combatValues.currentHealth);
        }

        public void UnattachUnit()
        {

        }
    }

}
