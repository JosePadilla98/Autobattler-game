using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace auttobattler
{
    public class CreatureUIController : MonoBehaviour
    {
        [SerializeField]
        private SliderBar healthBar;

        [SerializeField]
        private SliderBar attackProgressBar;

        CreatureCombatLogic logic = new CreatureCombatLogic();

        private void Start()
        {
            attackProgressBar.SetMaxValue(Constants.VALUE_TO_COMPLETE_AN_ATTACK);
            logic.attackModule.progress.OnCurrentValueChanged += AttackProgressChanged;
        }

        private void FixedUpdate()
        {
            logic.Refresh();
        }

        private void AttackProgressChanged(float value)
        {
            attackProgressBar.SetValue(value);
        }
    }
}