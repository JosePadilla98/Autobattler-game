using System;
using UnityEngine;

namespace Autobattler.Units.InfoBars
{
    [Serializable]
    public class UnitInfoBars
    {
        [SerializeField] private SliderBar healthBar;

        public void AttachUnit(Fighter fighter)
        {
            healthBar.AttachMaxValue(fighter.Stats.GetStat(StatsNames.HEALTH));
            healthBar.AttachValue(fighter.combatValues.currentHealth);
        }

        public void UnattachUnit()
        {
        }
    }
}