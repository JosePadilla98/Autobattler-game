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

        private UnitAnimationsController animationsController;
        private UnitCombatInstance combatInstance;
        public UnitCombatInstance CombatInstance { get => combatInstance; }

        protected virtual void Awake()
        {
            animationsController = GetComponent<UnitAnimationsController>();
        }

        public void CreateCombatInstance(BuildedUnit build, Side team) 
        {
            /// <summary>
            /// When the unit is summoned by the level, this methods is called before Awake
            /// </summary>

            combatInstance = new UnitCombatInstance(build, team);
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

        public void AttachUnit(UnitCombatInstance unit)
        {
            attackProgressBar.AttachMaxValue(unit.values.attackDuration);
            attackProgressBar.AttachValue(unit.values.attackProgress);

            healthBar.AttachMaxValue(unit.values.maxHealth);
            healthBar.AttachValue(unit.values.health);
        }

        public void UnattachUnit()
        {
            attackProgressBar.Unnatach();
            healthBar.Unnatach();
        }
    }

}
