using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Auttobattler.Combat;

namespace Auttobattler
{
	public class SliderBar : MonoBehaviour
	{
		[SerializeField]
		private Slider slider;
		[SerializeField]
		private Gradient gradient;
		[SerializeField]
		private Image fill;

		private CombatValue value;
		private CombatValue maxValue;

		private void SetMaxValue(float value)
		{
			slider.maxValue = value;
			fill.color = gradient.Evaluate(1f);
		}

		private void SetValue(float value)
		{
			slider.value = value;
			fill.color = gradient.Evaluate(slider.normalizedValue);
		}

        #region EVENTS_ATTACHERS

        public void AttachMaxValue(CombatValue v)
		{
			maxValue = v;
			v.OnValueChanged += SetMaxValue;

			SetMaxValue(v.Value);
		}
		public void AttachValue(CombatValue v)
		{
			value = v;
			v.OnValueChanged += SetValue;
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
