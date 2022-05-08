using UnityEngine;
using Auttobattler.Backend.Run.CombatState;
using Auttobattler.Backend.Run;

namespace Auttobattler.Frontend.CombatState
{
    [RequireComponent(typeof(Animator))]
    public class UnitAnimationsController : MonoBehaviour
    {
        private Animator animator;
        private Fighter attachedFighter;

        #region ANIMATION_NAMES

        private const string ATTACK = "Attack";
        private const string MIRROR_ATTACK = "AttackMirror";

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        #region ATTACH_METHODS

        public void AttachUnit(Fighter unit)
        {
            attachedFighter = unit;
            unit.attackSys.OnAttackCasted += AttackAnimation;
        }

        public void UnnatachUnit()
        {
            attachedFighter.attackSys.OnAttackCasted -= AttackAnimation;
            attachedFighter = null;
        }
        #endregion

        private void AttackAnimation()
        {
            Side side = attachedFighter.Position.side;

            if (side == Side.LEFT)
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
