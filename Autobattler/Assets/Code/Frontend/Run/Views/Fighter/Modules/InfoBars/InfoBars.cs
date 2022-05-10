using Auttobattler.Backend;
using UnityEngine;

namespace Auttobattler.Frontend
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
