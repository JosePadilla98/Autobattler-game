using Assets.Code.Backend.RunLogic.Combat.Fighter;
using Auttobattler.Backend.RunLogic.Management;
using UnityEngine;

namespace Assets.Code.Frontend.UnitView.Unit.Components.InfoBars
{
    [System.Serializable]
    public class UnitInfoBars
    {
        [SerializeField]
        private SliderBar healthBar;

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
