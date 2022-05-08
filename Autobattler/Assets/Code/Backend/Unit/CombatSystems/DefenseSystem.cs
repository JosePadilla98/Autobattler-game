using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public class DefenseSystem : CombatSystem
    {
        public DefenseSystem(Fighter parent) : base(parent) { }

        #region Properties
        public float PhysicalDefense { get => parent.Stats.GetStatValue(StatsNames.PHYSICAL_DEFENSE); }
        public float MagicalDefense { get => parent.Stats.GetStatValue(StatsNames.MAGICAL_DEFENSE); }
        #endregion

        public void BeAttacked(DamageData damageData)
        {
            float defenseValue = (damageData.type == DamageType.PHYSICAL) ? PhysicalDefense : MagicalDefense;
            float damage = damageData.value / defenseValue;
            parent.healthSys.ReceiveDamage(damage);
        }
    }
}
