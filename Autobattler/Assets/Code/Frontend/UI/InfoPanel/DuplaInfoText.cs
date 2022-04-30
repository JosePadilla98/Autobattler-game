using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Auttobattler.Combat;

namespace Auttobattler
{
    [System.Serializable]
    public class DuplaInfoText : DuplaInfo
    {
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private string textToShow;

        protected override void OnMaxChanged(float value)
        {
            RefreshText();
        }

        protected override void OnValueChanged(float value)
        {
            RefreshText();
        }

        private void RefreshText()
        {
            text.text = textToShow + ": " + (int)value.Value + "/" + (int)maxValue.Value;
        }

        public void SetColor(Color color)
        {
            text.color = color;
        }

        public override void AttachValues(CombatValue max, CombatValue v)
        {
            base.AttachValues(max, v);
            RefreshText();
        }
    }

    public abstract class DuplaInfo
    {
        protected CombatValue value;
        protected CombatValue maxValue;

        protected abstract void OnMaxChanged(float value);
        protected abstract void OnValueChanged(float value);

        #region EVENTS_ATTACHERS

        public virtual void AttachValues(CombatValue max, CombatValue v)
        {
            maxValue = max;
            maxValue.OnValueChanged += OnMaxChanged;

            value = v;
            v.OnValueChanged += OnValueChanged;
        }

        public void Unnatach()
        {
            value.OnValueChanged -= OnValueChanged;
            maxValue.OnValueChanged -= OnMaxChanged;

            value = null;
            maxValue = null;
        }

        #endregion
    }
}
