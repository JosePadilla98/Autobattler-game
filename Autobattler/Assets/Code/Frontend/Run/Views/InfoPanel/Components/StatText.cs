using Auttobattler.Backend.RunLogic.Management;
using TMPro;
using UnityEngine;

namespace Assets.Code.Frontend.Run.Views.InfoPanel.Components
{
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
