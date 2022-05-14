using System;
using Autobattler.Units;
using TMPro;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
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

        protected override void OnValueChanged()
        {
            RefreshText();
        }

        private void RefreshText()
        {
            text.text = textToShow + ": " + (int)value.Get() + "/" + (int)maxValue.Get();
        }

        public void SetColor(Color color)
        {
            text.color = color;
        }

        public override void AttachValues(IValueExpositor max, IValueExpositor v)
        {
            base.AttachValues(max, v);
            RefreshText();
        }
    }

    public abstract class DuplaInfo
    {
        protected IValueExpositor maxValue;
        protected IValueExpositor value;

        protected abstract void OnMaxChanged();
        protected abstract void OnValueChanged();

        #region EVENTS_ATTACHERS

        public virtual void AttachValues(IValueExpositor max, IValueExpositor v)
        {
            maxValue = max;
            maxValue.OnValueChanged += OnMaxChanged;

            value = v;
            v.OnValueChanged += OnValueChanged;
        }

        public void Unattach()
        {
            value.OnValueChanged -= OnValueChanged;
            maxValue.OnValueChanged -= OnMaxChanged;

            value = null;
            maxValue = null;
        }

        #endregion
    }
}