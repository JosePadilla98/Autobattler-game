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
		private Stat maxValue;

		private void SetMaxValue()
		{
			float value = maxValue.Get();
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
