using Auttobattler.Backend;
using TMPro;
using UnityEngine;

namespace Auttobattler.Frontend
{
    [System.Serializable]
    public class DuplaInfoText : DuplaInfo
    {
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private string textToShow;

        protected override void OnMaxChanged()
        {
            RefreshText();
        }

        protected override void OnValueChanged(float value)
        {
            RefreshText();
        }

        private void RefreshText()
        {
            text.text = textToShow + ": " + (int)value.Value + "/" + (int)maxValue.Get();
        }

        public void SetColor(Color color)
        {
            text.color = color;
        }

        public override void AttachValues(Stat max, CombatValue v)
        {
            base.AttachValues(max, v);
            RefreshText();
        }
    }

    public abstract class DuplaInfo
    {
        protected CombatValue value;
        protected Stat maxValue;

        protected abstract void OnMaxChanged();
        protected abstract void OnValueChanged(float value);

        #region EVENTS_ATTACHERS

        public virtual void AttachValues(Stat max, CombatValue v)
        {
            maxValue = max;
            maxValue.onValueChanged += OnMaxChanged;

            value = v;
            v.onValueChanged += OnValueChanged;
        }

        public void Unattach()
        {
            value.onValueChanged -= OnValueChanged;
            maxValue.onValueChanged -= OnMaxChanged;

            value = null;
            maxValue = null;
        }

        #endregion
    }
}
