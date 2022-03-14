using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;
using UnityEngine.UI;

namespace Auttobattler
{
    public class Unit : MonoBehaviour
    {
        [SerializeField]
        private UnitAnimationsController animationsController;
        public UnitInfoBars infoBars;
        public Image image;

        private UnitCombatInstance combatInstance;

        public UnitCombatInstance CombatInstance { get => combatInstance; }

        /// <summary>
        /// When the unit is summoned by the level, this methods is called before Awake
        /// </summary>
        public void CreateCombatInstance(BuildedUnit build, Side team) 
        {
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
