using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public class AttackSystem : CombatSystem
    {
        public AttackSystem(UnitCombatInstance parent) : base(parent) { }

        public Action OnAttackCasted;
        public Action OnHitMade;

        public void LaunchAttack(AttackType attackType)
        {
            float attackValue = (attackType == AttackType.PHYSICAL) ? values.attack.Value : values.magic.Value;

            List<UnitCombatInstance> objetives = TargetsProcessor.GetObjetives(TargetTypes.ENEMY_CLOSEST, Position, Battlefield.Instance);
            foreach (var unit in objetives)
            {
                float rawValue = attackValue * BalanceConstants.DAMAGE_MULTIPLIER;
                unit.defenseSys.BeAttacked(new AttackData(rawValue, AttackType.PHYSICAL));
            }

            OnAttackCasted?.Invoke();
        }
    }

    public enum DamageType
    {
        PHYSICAL, MAGICAL
    }

    public struct AttackData
    {
        public float scaleFactor;
        public DamageType StatScale;
    }
}
