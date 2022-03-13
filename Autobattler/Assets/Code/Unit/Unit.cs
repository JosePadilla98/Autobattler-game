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

        public UnitCombatModule combatModule;

        public void CreateCombatInstance(BuildedUnit build) 
        {
            combatModule = new UnitCombatModule(build);
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

        public void AttachUnit(UnitCombatModule unit)
        {
            attackProgressBar.AttachMaxValue(unit.values.attackDuration);
            attackProgressBar.AttachValue(unit.values.attackProgress);
        }

        public void UnattachUnit()
        {
            attackProgressBar.Unnatach();
        }
    }

}
