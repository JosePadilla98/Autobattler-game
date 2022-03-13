using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class Unit : MonoBehaviour
    {
        public UnitInfoBars infoBars;
        public BuildedUnit build;
        public UnitCombatInstance combatInstance;

        public void CreateCombatInstance() 
        {
            combatInstance = new UnitCombatInstance(build);
            infoBars.AttachUnit(combatInstance);
        }

        private void FixedUpdate()
        {
            combatInstance.Refresh();
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
        }

        public void UnattachUnit()
        {
            attackProgressBar.Unnatach();
        }
    }

}
