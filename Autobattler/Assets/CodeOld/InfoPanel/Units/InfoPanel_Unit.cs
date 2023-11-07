using AutobattlerOld.Units;
using AutobattlerOld.Units.Combat;
using AutobattlerOld.Units.Management;
using AutobattlerOld.UnitsListScreen;
using UnityEngine;

namespace AutobattlerOld.InfoPanel.Units
{
    public class InfoPanel_Unit : MonoBehaviour
    {
        [Header("Column 1")]
        [SerializeField]
        private DuplaInfoText health;

        [SerializeField]
        private StatText defense;

        [Space(10)]
        [Header("Column 2")]
        [SerializeField]
        private StatText strength;

        [SerializeField]
        private StatText attackSpeed;

        [SerializeField]
        private StatText magicalPower;

        private void SetColors()
        {
            health.SetColor();
            defense.SetColor();

            strength.SetColor();
            attackSpeed.SetColor();
            magicalPower.SetColor();
        }

        private void Start()
        {
            SetColors();
        }

        #region EVENT METHODS

        public void AttachUnit(Unit unit)
        {
            FillPanel(unit.statsContainer);
        }

        public void UnattachUnit(Unit unit)
        {
            EmptyPanel();
        }

        public void AttachFighter(Fighter fighter)
        {
            FillPanel(fighter.StatsContainer, fighter.combatValues);
        }

        public void UnattachFighter(Fighter fighter)
        {
            EmptyPanel();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitList_Slot"></param>
        public void AttachUnitFromUnitList(MonoBehaviour unitList_Slot)
        {
            var slot = (UnitsList_Slot)unitList_Slot;

            AttachUnit(((UnitView)unitList_Slot).unit);
        }

        #endregion

        private void EmptyPanel()
        {
            health.Unattach();
            defense.Unattach();

            strength.Unattach();
            attackSpeed.Unattach();
            magicalPower.Unattach();

            gameObject.SetActive(false);
        }

        private void FillPanel(StatsContainer statsContainer, CombatValues combatValues = null)
        {
            defense.Attach(statsContainer.GetStat(StatsNames.DEFENSE));
            strength.Attach(statsContainer.GetStat(StatsNames.STRENGTH));
            magicalPower.Attach(statsContainer.GetStat(StatsNames.MAGIC_POWER));
            attackSpeed.Attach(statsContainer.GetStat(StatsNames.ATTACK_SPEED));

            if (combatValues != null)
            {
                health.AttachValues(
                    statsContainer.GetStat(StatsNames.HEALTH),
                    combatValues.currentHealth
                );
            }
            else
            {
                health.AttachValues(
                    statsContainer.GetStat(StatsNames.HEALTH),
                    statsContainer.GetStat(StatsNames.HEALTH)
                );
            }

            gameObject.SetActive(true);
        }
    }
}
