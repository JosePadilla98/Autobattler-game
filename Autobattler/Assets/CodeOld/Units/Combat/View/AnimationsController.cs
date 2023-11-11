using AutobattlerOld.Grid;
using UnityEngine;

namespace AutobattlerOld.Units.Combat.View
{
    [RequireComponent(typeof(Animator))]
    public class AnimationsController : MonoBehaviour
    {
        private Animator animator;
        private Fighter attachedFighter;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void AttackAnimation()
        {
            var side = attachedFighter.Position.side;

            if (side == Side.LEFT)
                animator.SetTrigger(ATTACK);
            else
                animator.SetTrigger(MIRROR_ATTACK);
        }

        #region ANIMATION_NAMES

        private const string ATTACK = "Attack";
        private const string MIRROR_ATTACK = "AttackMirror";

        #endregion

        #region ATTACH_METHODS

        public void AttachUnit(Fighter unit)
        {
            attachedFighter = unit;
            unit.basicAttackSys.OnAttackCasted += AttackAnimation;
        }

        public void UnnatachUnit()
        {
            attachedFighter.basicAttackSys.OnAttackCasted -= AttackAnimation;
            attachedFighter = null;
        }

        #endregion
    }
}
