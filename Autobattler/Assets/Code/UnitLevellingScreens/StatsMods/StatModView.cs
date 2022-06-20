using System;
using System.Text;
using Autobattler.ExpModule.Stats;
using Autobattler.Units;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.UnitLevellingScreens
{
    public class StatModView : MonoBehaviour
    {
        public TextMeshProUGUI addedStatText;
        public TextMeshProUGUI substractedStatText;

        public void Inflate(StatModElement element)
        {
            float realAddedValue = element.statToAdd.GetRealValue(element.ModValue);
            StringBuilder textBuilder1 = new StringBuilder();
            textBuilder1.AppendFormat("+{0} {1}.", realAddedValue.ToString("0.00"), element.statToAdd.GetName());
            addedStatText.text = textBuilder1.ToString();

            float realSubstractedValue = element.statToSubstract.GetRealValue(element.ModValue);
            StringBuilder textBuilder2 = new StringBuilder();
            textBuilder2.AppendFormat("-{0} {1}.", realSubstractedValue.ToString("0.00"), element.statToSubstract.GetName());
            substractedStatText.text = textBuilder2.ToString();
        }

        public void OnClick()
        {

        }
    }
}