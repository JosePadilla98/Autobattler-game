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

		private ValuePair valuePair;

		private void SetMaxValue(float value)
		{
			slider.maxValue = value;
			slider.value = value;
			fill.color = gradient.Evaluate(1f);
		}

		private void SetValue(float value)
		{
			slider.value = value;
			fill.color = gradient.Evaluate(slider.normalizedValue);
		}

		public void AttachValuePair(ValuePair valuePair)
		{
			this.valuePair = valuePair;
			valuePair.OnCurrentValueChanged += SetValue;
			valuePair.OnMaxValueChanged += SetMaxValue;
		}

		public void Unnatach()
		{
			valuePair.OnCurrentValueChanged -= SetValue;
			valuePair.OnMaxValueChanged -= SetMaxValue;
			this.valuePair = null;
		}
	}
}
