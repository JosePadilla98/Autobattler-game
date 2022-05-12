using System;
using Autobattler.Unit.Unit;
using UnityEngine;

namespace Autobattler.Unit.Fighter.View.InfoBars
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