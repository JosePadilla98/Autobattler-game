using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public class DefenseSystem : CombatSystem
    {
        public DefenseSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public float Defense { get => parent.values.defense.Value; set => parent.values.attack.Value = value; }
        public float MagicDefense { get => parent.values.magicDefense.Value; set => parent.values.magicDefense.Value = value; }
        #endregion

        public void BeAttacked(AttackData data)
        {
            float defenseValue = (data.type == AttackType.PHYSICAL) ? Defense : MagicDefense;
            float damage = data.rawDamage / defenseValue;
            parent.healthSys.ReceiveDamage(damage);
        }
    }
}
