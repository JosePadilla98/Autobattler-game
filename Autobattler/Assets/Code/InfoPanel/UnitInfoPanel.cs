using System;
using Autobattler.Configs;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    public class UnitInfoPanel : MonoBehaviour
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
      
        [Space(10)] [Header("Column 4")] 
        [SerializeField]
        private DuplaInfoText vigor;
        [SerializeField]
        private StatText reinvigoration;
        [SerializeField]
        private StatText physicalFatigue;

        public bool IsShowing { get; private set; }

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
            gameObject.SetActive(false);
        }

        #region EVENT METHODS

        public void AttachUnit(Unit unit)
        {
            FillTexts(unit.stats);
        }

        public void UnattachUnit(Unit unit)
        {
            gameObject.SetActive(false);
        }

        public void AttachFighter(Fighter fighter)
        {
            FillTexts(fighter.Stats, fighter.combatValues);
        }

        public void UnattachFighter(Fighter fighter)
        {
            EmptyTexts();
        }

        #endregion

        private void OnDisable()
        {
            EmptyTexts();
        }

        private void EmptyTexts()
        {
            if (!IsShowing)
                return;

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

            IsShowing = false;
        }

        private void FillTexts(Stats stats, CombatValues combatValues = null)
        {

            healthRegen.Attach(stats.GetStat(StatsNames.HEALTH_REGEN));
            defense.Attach(stats.GetStat(StatsNames.PHYSICAL_DEFENSE));
            magicDefense.Attach(stats.GetStat(StatsNames.MAGICAL_DEFENSE));

            physicalAttack.Attach(stats.GetStat(StatsNames.PHYSICAL_ATTACK));
            physicalSpeed.Attach(stats.GetStat(StatsNames.PHYSICAL_SPEED));
            magicalAttack.Attach(stats.GetStat(StatsNames.MAGICAL_ATTACK));
            magicalSpeed.Attach(stats.GetStat(StatsNames.MAGICAL_SPEED));


            manaRegen.Attach(stats.GetStat(StatsNames.MANA_REGEN));
            magicalFatigue.Attach(stats.GetStat(StatsNames.MAGICAL_FATIGUE));
            intellect.Attach(stats.GetStat(StatsNames.INTELLECT));


            reinvigoration.Attach(stats.GetStat(StatsNames.REINVIGORATION));
            physicalFatigue.Attach(stats.GetStat(StatsNames.PHYSICAL_FATIGUE));

            if (combatValues != null)
            {
                health.AttachValues(stats.GetStat(StatsNames.HEALTH), combatValues.currentHealth);
                mana.AttachValues(stats.GetStat(StatsNames.MANA), combatValues.currentMana);
                vigor.AttachValues(stats.GetStat(StatsNames.VIGOR), combatValues.currentVigor);
            }
            else
            {
                health.AttachValues(stats.GetStat(StatsNames.HEALTH), stats.GetStat(StatsNames.HEALTH));
                mana.AttachValues(stats.GetStat(StatsNames.MANA), stats.GetStat(StatsNames.MANA));
                vigor.AttachValues(stats.GetStat(StatsNames.VIGOR), stats.GetStat(StatsNames.VIGOR));
            }


            gameObject.SetActive(true);
            IsShowing = true;
        }
    }
}