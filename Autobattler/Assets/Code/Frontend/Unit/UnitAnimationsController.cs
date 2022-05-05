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

        #region ANIMATION_NAMES

        private const string ATTACK = "Attack";
        private const string MIRROR_ATTACK = "AttackMirror";

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        #region ATTACH_METHODS

        public void AttachUnit(UnitCombatInstance unit)
        {
            attachedUnit = unit;
            unit.attackSys.OnAttackCasted += AttackAnimation;
        }

        public void UnnatachUnit()
        {
            attachedUnit.attackSys.OnAttackCasted -= AttackAnimation;
            attachedUnit = null;
        }
        #endregion

        private void AttackAnimation()
        {
            if (attachedUnit.grid.side == Side.LEFT)
            {
                animator.SetTrigger(ATTACK);
            }
            else
            {
                animator.SetTrigger(MIRROR_ATTACK);
            }
        }
    }
}
