using Autobattler.Configs;
using Autobattler.Units;
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


        private ColorPalette ColorPalette => null;

        public static UnitInfoPanel Instance { get; set; }

        public bool IsShowing { get; private set; }

        private void Start()
        {
            SetColors();
            gameObject.SetActive(false);
        }

        private void SetColors()
        {
            //
            health.SetColor(ColorPalette.health);
            healthRegen.SetColor(ColorPalette.health);
            defense.SetColor(ColorPalette.defense);
            magicDefense.SetColor(ColorPalette.magicDefense);

            //
            physicalAttack.SetColor(ColorPalette.attack);
            physicalSpeed.SetColor(ColorPalette.attack);
            magicalAttack.SetColor(ColorPalette.magic);
            magicalSpeed.SetColor(ColorPalette.magic);

            mana.SetColor(ColorPalette.mana);
            manaRegen.SetColor(ColorPalette.mana);
            magicalFatigue.SetColor(ColorPalette.vigor);
            intellect.SetColor(ColorPalette.intellect);

            vigor.SetColor(ColorPalette.vigor);
            reinvigoration.SetColor(ColorPalette.vigor);
            physicalFatigue.SetColor(ColorPalette.vigor);
        }

        public void AttachUnit(Stats stats, CombatValues combatValues = null)
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

        public void Unattach()
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
            IsShowing = false;
        }

       
    }
}