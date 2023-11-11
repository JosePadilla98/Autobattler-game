using System;
using UnityEngine;

namespace AutobattlerOld.Units.Combat.View.InfoBars
{
    [Serializable]
    public class UnitInfoBars
    {
        [SerializeField]
        private SliderBar healthBar;

        public void AttachUnit(Fighter fighter)
        {
            healthBar.AttachMaxValue(fighter.StatsContainer.GetStat(StatsNames.HEALTH));
            healthBar.AttachValue(fighter.combatValues.currentHealth);
        }

        public void UnattachUnit() { }
    }
}
