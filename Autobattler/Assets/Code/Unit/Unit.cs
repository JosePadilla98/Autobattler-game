using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;
using UnityEngine.UI;

namespace Auttobattler
{
    public class Unit : MonoBehaviour
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
            /// <summary>
            /// When the unit is summoned by the level, this methods is called before Awake
            /// </summary>

            this.CombatInstance = combatInstance;
        }

        public void PreparativesToBattle()
        {
            infoBars.AttachUnit(CombatInstance);
            animationsController?.AttachUnit(CombatInstance);
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
                ultimateProgressBar.AttachMaxValue(unit.values.ultimateChargeToCast);
                ultimateProgressBar.AttachValue(unit.values.ultimateProgress);
            }
        }

        public void UnattachUnit()
        {
            healthBar.Unnatach();
            attackProgressBar.Unnatach();
            ultimateProgressBar.Unnatach();
        }
    }

}
