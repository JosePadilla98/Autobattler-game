using UnityEngine;
using TMPro;
using Auttobattler.Backend.Run.ManagementState;
using Auttobattler.Backend.Run.CombatState;

namespace Auttobattler.Frontend
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

        [Space(10)]
        [Header("Column 4")]
        [SerializeField]
        private DuplaInfoText vigor;
        [SerializeField]
        private StatText reinvigoration;
        [SerializeField]
        private StatText physicalFatigue;

        private ColorPalette ColorPalette { get => GameAssets.Instance.colorPalette; }
        public static UnitInfoPanel Instance { 
            get => instance;
            set
            {
                instance = value;
            }
        }
        private static UnitInfoPanel instance;

        public bool IsShowing { get => isShowing; }
        private bool isShowing;
      

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

        public void AttachUnit(Fighter fighter)
        {
            health.AttachValues(fighter.Stats.GetStat(StatsNames.HEALTH), fighter.combatValues.currentHealth);
            healthRegen.Attach(fighter.Stats.GetStat(StatsNames.HEALTH_REGEN));
            defense.Attach(fighter.Stats.GetStat(StatsNames.PHYSICAL_DEFENSE));
            magicDefense.Attach(fighter.Stats.GetStat(StatsNames.MAGICAL_DEFENSE));

            physicalAttack.Attach(fighter.Stats.GetStat(StatsNames.PHYSICAL_ATTACK));
            physicalSpeed.Attach(fighter.Stats.GetStat(StatsNames.PHYSICAL_SPEED));
            magicalAttack.Attach(fighter.Stats.GetStat(StatsNames.MAGICAL_ATTACK));
            magicalSpeed.Attach(fighter.Stats.GetStat(StatsNames.MAGICAL_SPEED));

            mana.AttachValues(fighter.Stats.GetStat(StatsNames.MANA), fighter.combatValues.currentMana);
            manaRegen.Attach(fighter.Stats.GetStat(StatsNames.MANA_REGEN));
            magicalFatigue.Attach(fighter.Stats.GetStat(StatsNames.MAGICAL_FATIGUE));
            intellect.Attach(fighter.Stats.GetStat(StatsNames.INTELLECT));

            vigor.AttachValues(fighter.Stats.GetStat(StatsNames.VIGOR), fighter.combatValues.currentVigor);
            reinvigoration.Attach(fighter.Stats.GetStat(StatsNames.REINVIGORATION));
            physicalFatigue.Attach(fighter.Stats.GetStat(StatsNames.PHYSICAL_FATIGUE));

            gameObject.SetActive(true);
            isShowing = true;
        }

        public void UnattachUnit()
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
            isShowing = false;
        }
    }

    [System.Serializable]
    public class StatText
    {
        public TextMeshProUGUI text;
        public string textToShow;
        private Stat stat;

        public void SetColor(Color color)
        {
            text.color = color;
        }

        public void Attach(Stat stat)
        {
            this.stat = stat;
            stat.onValueChanged += OnValueChanged;
            ChangeText(stat.Get());
        }

        public void Unattach()
        {
            stat.onValueChanged -= OnValueChanged;
        }

        public void OnValueChanged()
        {
            ChangeText(stat.Get());
        }

        private void ChangeText(float f)
        {
            text.text = textToShow + ": " + f;
        }
    }
}
