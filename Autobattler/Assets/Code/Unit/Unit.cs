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

        public UnitCombatInstance combatInstance;

        /// <summary>
        /// Cuando lo invoca el nivel, se llama antes del Awake. Esta funci´´on debería ser llamada sólamente por el
        /// CombatController. Cambiar esto.
        /// </summary>
        public void CreateCombatInstance(BuildedUnit build, Side team) 
        {
            combatInstance = new UnitCombatInstance(build, team);
            infoBars.AttachUnit(combatInstance);
            animationsController?.AttachUnit(combatInstance);
        }

        public void PreparativesToBattle()
        {
            
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
