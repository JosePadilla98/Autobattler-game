using System;
using Autobattler.Units;
using TMPro;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
    public class StatText
    {
        private IValueExpositor valueExpositor;
        public TextMeshProUGUI text;
        public string textToShow;

        public void SetColor(Color color)
        {
            text.color = color;
        }

        public void Attach(IValueExpositor valueExpositor)
        {
            this.valueExpositor = valueExpositor;
            valueExpositor.OnValueChanged += OnValueChanged;
            ChangeText(valueExpositor.Get());
        }

        public void Unattach()
        {
            valueExpositor.OnValueChanged -= OnValueChanged;
        }

        public void OnValueChanged()
        {
            ChangeText(valueExpositor.Get());
        }

        private void ChangeText(float f)
        {
            text.text = textToShow + ": " + f;
        }
    }
}