using System;
using Autobattler.Colors;
using Autobattler.Units;
using TMPro;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
    public class StatText
    {
        private IValueExpositor valueExpositor;
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private string textToShow;
        [SerializeField]
        private ColorModel colorModel;

        public void SetColor()
        {
            text.color = colorModel.color;
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