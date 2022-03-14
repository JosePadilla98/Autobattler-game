using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;

namespace Auttobattler
{
    [RequireComponent(typeof(Animator))]
    public class UnitAnimationsController : MonoBehaviour
    {
        private Animator animator;
        private UnitCombatInstance attachedUnit;

        private const string ATTACK = "Attack";

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        #region ATTACH_METHODS

        public void AttachUnit(UnitCombatInstance unit)
        {
            unit.attackSys.OnAttack += AttackAnimation;
        }

        public void UnnatachUnit()
        {
            attachedUnit.attackSys.OnAttack -= AttackAnimation;
        }
        #endregion

        private void AttackAnimation()
        {
            animator.SetTrigger(ATTACK);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackAnimation();
            }    
        }
    }
}
