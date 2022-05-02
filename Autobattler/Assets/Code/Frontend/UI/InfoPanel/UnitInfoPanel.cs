using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class UnitInfoPanel : MonoBehaviour
    {
        [Header("Column 1")]
        [SerializeField]
        private DuplaInfoText health;
        [SerializeField]
        private StatText attack;
        [SerializeField]
        private StatText attackSpeed;
        [SerializeField]
        private StatText defense;

        [Space(10)]
        [Header("Column 2")]
        [SerializeField]
        private DuplaInfoText ult;
        [SerializeField]
        private StatText ultRegen;
        [SerializeField]
        private StatText magic;
        [SerializeField]
        private StatText magicDefense;

        [Space(10)]
        [Header("Column 3")]
        [SerializeField]
        private DuplaInfoText mana;
        [SerializeField]
        private StatText manaRegen;
        [SerializeField]
        private StatText cdr;

        [Space(10)]
        [Header("Column 4")]
        [SerializeField]
        private DuplaInfoText vigor;
        [SerializeField]
        private StatText reinvigoration;
        [SerializeField]
        private StatText aEncumbrance;
        [SerializeField]
        private StatText mEncumbrance;

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
            attack.SetColor(ColorPalette.attack);
            attackSpeed.SetColor(ColorPalette.attack);
            defense.SetColor(ColorPalette.defense);

            //
            ult.SetColor(ColorPalette.ult);
            ultRegen.SetColor(ColorPalette.ult);
            magic.SetColor(ColorPalette.magic);
            magicDefense.SetColor(ColorPalette.magicDefense);

            //
            mana.SetColor(ColorPalette.mana);
            manaRegen.SetColor(ColorPalette.mana);
            cdr.SetColor(ColorPalette.cdr);

            //
            vigor.SetColor(ColorPalette.vigor);
            reinvigoration.SetColor(ColorPalette.vigor);
            aEncumbrance.SetColor(ColorPalette.vigor);
            mEncumbrance.SetColor(ColorPalette.vigor);
        }

        public void AttachUnit(UnitCombatInstance unit)
        {
            health.AttachValues(unit.values.maxHealth, unit.values.health);
            attack.Attach(unit.values.attack);
            attackSpeed.Attach(unit.values.attackSpeed);
            defense.Attach(unit.values.defense);

            ult.AttachValues(unit.values.ultimateCost, unit.values.ultimateProgress);
            ultRegen.Attach(unit.values.ultimateRegen);
            magic.Attach(unit.values.magic);
            magicDefense.Attach(unit.values.magicDefense);

            mana.AttachValues(unit.values.maxMana, unit.values.currentMana);
            manaRegen.Attach(unit.values.manaRegen);
            cdr.Attach(unit.values.cdr);

            vigor.AttachValues(unit.values.vigor, unit.values.currentVigor);
            reinvigoration.Attach(unit.values.reinvigoration);
            aEncumbrance.Attach(unit.values.aEncumbrance);
            mEncumbrance.Attach(unit.values.mEncumbrance);

            gameObject.SetActive(true);
            isShowing = true;
        }

        public void UnattachUnit()
        {
            health.Unattach();
            attack.Unattach();
            attackSpeed.Unattach();
            defense.Unattach();

            ult.Unattach();
            ultRegen.Unattach();
            magic.Unattach();
            magicDefense.Unattach();

            mana.Unattach();
            manaRegen.Unattach();
            cdr.Unattach();

            vigor.Unattach();
            reinvigoration.Unattach();
            aEncumbrance.Unattach();
            mEncumbrance.Unattach();

            gameObject.SetActive(false);
            isShowing = false;
        }
    }

    [System.Serializable]
    public class StatText
    {
        public TextMeshProUGUI text;
        public string textToShow;
        private CombatValue v;

        public void SetColor(Color color)
        {
            text.color = color;
        }

        public void Attach(CombatValue v)
        {
            this.v = v;
            v.OnValueChanged += OnValueChanged;
            ChangeText(v.Value);
        }

        public void Unattach()
        {
            v.OnValueChanged -= OnValueChanged;
        }

        public void OnValueChanged(float f)
        {
            ChangeText(f);
        }

        private void ChangeText(float f)
        {
            text.text = textToShow + ": " + f;
        }
    }
}
