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
        
        public UnitCombatInstance combatModule;

        public void CreateCombatInstance(BuildedUnit build, Side team) 
        {
            combatModule = new UnitCombatInstance(build, team);
            infoBars.AttachUnit(combatModule);
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
