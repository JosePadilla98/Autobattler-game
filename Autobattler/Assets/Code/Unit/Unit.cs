using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    public class Unit : MonoBehaviour, IPointerClickHandler
    {
        public UnitInfoBars infoBars;
        public Image image;
        public Transform numberPopupsLocation;

        private UnitAnimationsController animationsController;
        private UnitCombatInstance combatInstance;

        public UnitCombatInstance CombatInstance { get => combatInstance; 
            set 
            { 
                combatInstance = value;
                combatInstance.gameObject = this; 
            } 
        }

        protected virtual void Awake()
        {
            animationsController = GetComponent<UnitAnimationsController>();
        }

        public void CreateCombatInstance(BuildedUnit build, Side team)
        {
            CombatInstance = new UnitCombatInstance(build, team);
        }

        public void AttachCombatInstance(UnitCombatInstance combatInstance)
        {
            this.CombatInstance = combatInstance;
        }

        public void PreparativesToBattle()
        {
            infoBars.AttachUnit(CombatInstance);
            animationsController?.AttachUnit(CombatInstance);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UnitInfoPanel.Instance.AttachUnit(CombatInstance);
        }
    }

    [System.Serializable]
    public class UnitInfoBars
    {
        [SerializeField]
        private SliderBar healthBar;
        [SerializeField]
        private SliderBar attackProgressBar;
        [SerializeField]
        private SliderBar ultimateProgressBar;

        public void AttachUnit(UnitCombatInstance unit)
        {
            healthBar.AttachMaxValue(unit.values.maxHealth);
            healthBar.AttachValue(unit.values.health);

            attackProgressBar.AttachMaxValue(unit.values.attackDuration);
            attackProgressBar.AttachValue(unit.values.attackProgress);

            if (ultimateProgressBar != null)
            {
                ultimateProgressBar.AttachMaxValue(unit.values.ultimateCost);
                ultimateProgressBar.AttachValue(unit.values.ultimateProgress);
            }
        }

        public void UnattachUnit()
        {
            healthBar.Unnatach();
            attackProgressBar.Unnatach();

            if (ultimateProgressBar != null)
            {
                ultimateProgressBar.Unnatach();
            }
        }
    }

}
