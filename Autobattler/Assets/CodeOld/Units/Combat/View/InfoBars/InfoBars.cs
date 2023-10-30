using System;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.Units.Combat.View.InfoBars
{
    [Serializable]
    public class UnitInfoBars
    {
        [SerializeField]
        private SliderBar healthBar;

        [SerializeField]
        private SliderBar vigorBar;

        [SerializeField]
        private SliderBar manaBar;

        public void AttachUnit(Fighter fighter)
        {
            healthBar.AttachMaxValue(fighter.StatsContainer.GetStat(OldStatsNames.HEALTH));
            healthBar.AttachValue(fighter.combatValues.currentHealth);

            vigorBar.AttachMaxValue(fighter.StatsContainer.GetStat(OldStatsNames.VIGOR));
            vigorBar.AttachValue(fighter.combatValues.currentVigor);

            manaBar.AttachMaxValue(fighter.StatsContainer.GetStat(OldStatsNames.MANA));
            manaBar.AttachValue(fighter.combatValues.currentMana);
        }

        public void UnattachUnit() { }
    }
}
