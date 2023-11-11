using UnityEngine;
using UnityEngine.UI;

namespace AutobattlerOld.Units.Combat.View.InfoBars
{
    public class SliderBar : MonoBehaviour
    {
        [SerializeField]
        private Image fill;

        [SerializeField]
        private Gradient gradient;

        [SerializeField]
        private Slider slider;

        private IValueExpositor value;
        private IValueExpositor maxValue;

        private void SetMaxValue()
        {
            slider.maxValue = maxValue.Get();
            fill.color = gradient.Evaluate(1f);
        }

        private void SetValue()
        {
            slider.value = value.Get();
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        #region EVENTS_ATTACHERS

        public void AttachMaxValue(IValueExpositor maxValue)
        {
            this.maxValue = maxValue;
            this.maxValue.OnValueChanged += SetMaxValue;

            SetMaxValue();
        }

        public void AttachValue(IValueExpositor v)
        {
            value = v;
            v.OnValueChanged += SetValue;

            SetValue();
        }

        public void Unnatach()
        {
            value.OnValueChanged -= SetValue;
            maxValue.OnValueChanged -= SetMaxValue;

            value = null;
            maxValue = null;
        }

        #endregion
    }
}
