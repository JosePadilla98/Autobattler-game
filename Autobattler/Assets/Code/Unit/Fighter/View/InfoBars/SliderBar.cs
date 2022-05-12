﻿using Autobattler.Unit.Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.Unit.Fighter.View.InfoBars
{
    public class SliderBar : MonoBehaviour
    {
        [SerializeField] private Image fill;

        [SerializeField] private Gradient gradient;

        private Stat maxValue;

        [SerializeField] private Slider slider;

        private CombatValue value;

        private void SetMaxValue()
        {
            var value = maxValue.Get();
            slider.maxValue = value;
            fill.color = gradient.Evaluate(1f);
        }

        private void SetValue(float value)
        {
            slider.value = value;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        #region EVENTS_ATTACHERS

        public void AttachMaxValue(Stat stat)
        {
            maxValue = stat;
            stat.onValueChanged += SetMaxValue;

            SetMaxValue();
        }

        public void AttachValue(CombatValue v)
        {
            value = v;
            v.onValueChanged += SetValue;

            SetValue(v.Value);
        }

        public void Unnatach()
        {
            value.onValueChanged -= SetValue;
            maxValue.onValueChanged -= SetMaxValue;

            value = null;
            maxValue = null;
        }

        #endregion
    }
}