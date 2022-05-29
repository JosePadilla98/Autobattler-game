using System;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Units.Combat.View.InfoBars
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
            healthBar.AttachMaxValue(fighter.Stats.GetStat(StatsNames.HEALTH));
            healthBar.AttachValue(fighter.combatValues.currentHealth);

            vigorBar.AttachMaxValue(fighter.Stats.GetStat(StatsNames.VIGOR));
            vigorBar.AttachValue(fighter.combatValues.currentVigor);

            manaBar.AttachMaxValue(fighter.Stats.GetStat(StatsNames.MANA));
            manaBar.AttachValue(fighter.combatValues.currentMana);
        }

        public void UnattachUnit()
        {
        }
    }
}