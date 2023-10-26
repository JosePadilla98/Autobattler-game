using System;
using System.Text;
using AutobattlerOld.Configs.Color;
using AutobattlerOld.ExpModule.Stats;
using AutobattlerOld.Units;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AutobattlerOld.UnitLevellingScreens
{
    public class StatModView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI addedStatText;
        [SerializeField]
        private TextMeshProUGUI substractedStatText;

        [SerializeField]
        private ColorModel selectedColor;
        private Color initialColor;

        private StatsModsChooser parent;

        private StatModElement element;
        public StatModElement Element => element;

        public void Inflate(StatModElement element, StatsModsChooser parent)
        {
            this.element = element;

            float realAddedValue = element.GetAdditionValue();
            StringBuilder textBuilder = new StringBuilder();
            textBuilder.AppendFormat("+{0} {1}.", realAddedValue.ToString("0.00"), element.statToAdd.GetName());
            addedStatText.text = textBuilder.ToString();

            textBuilder.Clear();
            float realSubstractedValue = element.GetSubstractionValue();
            textBuilder.AppendFormat("-{0} {1}.", realSubstractedValue.ToString("0.00"), element.statToSubstract.GetName());
            substractedStatText.text = textBuilder.ToString();

            this.parent = parent;

            initialColor = image.color;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            parent.OnChildSelected(this);
        }

        public void Select()
        {
            image.color = selectedColor.color;
        }

        public void Deselect()
        {
            image.color = initialColor;
        }

        private void OnDestroy()
        {
            parent = null;
        }
    }
}