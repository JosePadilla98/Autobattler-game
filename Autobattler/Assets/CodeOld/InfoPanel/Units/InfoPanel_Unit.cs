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
        private StatText healthRegen;

        [SerializeField]
        private StatText defense;

        [SerializeField]
        private StatText magicDefense;

        [Space(10)]
        [Header("Column 2")]
        [SerializeField]
        private StatText physicalAttack;

        [SerializeField]
        private StatText physicalSpeed;

        [SerializeField]
        private StatText magicalAttack;

        [SerializeField]
        private StatText magicalSpeed;

        [Space(10)]
        [Header("Column 3")]
        [SerializeField]
        private DuplaInfoText mana;

        [SerializeField]
        private StatText manaRegen;

        [SerializeField]
        private StatText magicalFatigue;

        [SerializeField]
        private StatText intellect;

        [Space(10)]
        [Header("Column 4")]
        [SerializeField]
        private DuplaInfoText vigor;

        [SerializeField]
        private StatText reinvigoration;

        [SerializeField]
        private StatText physicalFatigue;

        private void SetColors()
        {
            health.SetColor();
            healthRegen.SetColor();
            defense.SetColor();
            magicDefense.SetColor();

            physicalAttack.SetColor();
            physicalSpeed.SetColor();
            magicalAttack.SetColor();
            magicalSpeed.SetColor();

            mana.SetColor();
            manaRegen.SetColor();
            magicalFatigue.SetColor();
            intellect.SetColor();

            vigor.SetColor();
            reinvigoration.SetColor();
            physicalFatigue.SetColor();
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
            healthRegen.Unattach();
            defense.Unattach();
            magicDefense.Unattach();

            physicalAttack.Unattach();
            physicalSpeed.Unattach();
            magicalAttack.Unattach();
            magicalSpeed.Unattach();

            mana.Unattach();
            manaRegen.Unattach();
            magicalFatigue.Unattach();
            intellect.Unattach();

            vigor.Unattach();
            reinvigoration.Unattach();
            physicalFatigue.Unattach();

            gameObject.SetActive(false);
        }

        private void FillPanel(StatsContainer statsContainer, CombatValues combatValues = null)
        {
            healthRegen.Attach(statsContainer.GetStat(OldStatsNames.HEALTH_REGEN));
            defense.Attach(statsContainer.GetStat(OldStatsNames.PHYSICAL_DEFENSE));
            magicDefense.Attach(statsContainer.GetStat(OldStatsNames.MAGICAL_DEFENSE));

            physicalAttack.Attach(statsContainer.GetStat(OldStatsNames.PHYSICAL_ATTACK));
            physicalSpeed.Attach(statsContainer.GetStat(OldStatsNames.PHYSICAL_SPEED));
            magicalAttack.Attach(statsContainer.GetStat(OldStatsNames.MAGICAL_ATTACK));
            magicalSpeed.Attach(statsContainer.GetStat(OldStatsNames.MAGICAL_SPEED));

            manaRegen.Attach(statsContainer.GetStat(OldStatsNames.MANA_REGEN));
            magicalFatigue.Attach(statsContainer.GetStat(OldStatsNames.MAGICAL_FATIGUE));
            intellect.Attach(statsContainer.GetStat(OldStatsNames.INTELLECT));

            reinvigoration.Attach(statsContainer.GetStat(OldStatsNames.REINVIGORATION));
            physicalFatigue.Attach(statsContainer.GetStat(OldStatsNames.PHYSICAL_FATIGUE));

            if (combatValues != null)
            {
                health.AttachValues(
                    statsContainer.GetStat(OldStatsNames.HEALTH),
                    combatValues.currentHealth
                );
                mana.AttachValues(
                    statsContainer.GetStat(OldStatsNames.MANA),
                    combatValues.currentMana
                );
                vigor.AttachValues(
                    statsContainer.GetStat(OldStatsNames.VIGOR),
                    combatValues.currentVigor
                );
            }
            else
            {
                health.AttachValues(
                    statsContainer.GetStat(OldStatsNames.HEALTH),
                    statsContainer.GetStat(OldStatsNames.HEALTH)
                );
                mana.AttachValues(
                    statsContainer.GetStat(OldStatsNames.MANA),
                    statsContainer.GetStat(OldStatsNames.MANA)
                );
                vigor.AttachValues(
                    statsContainer.GetStat(OldStatsNames.VIGOR),
                    statsContainer.GetStat(OldStatsNames.VIGOR)
                );
            }

            gameObject.SetActive(true);
        }
    }
}
