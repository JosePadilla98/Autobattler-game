using System;
using Autobattler.Unit.Unit;
using TMPro;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
    public class StatText
    {
        private Stat stat;
        public TextMeshProUGUI text;
        public string textToShow;

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