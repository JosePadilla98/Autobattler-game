using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public class HealthSystem : CombatSystem
    {
        public HealthSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public float MaxHealth { get => parent.values.maxHealth.Value; set => parent.values.maxHealth.Value = value; }
        public float Health { get => parent.values.health.Value; set => parent.values.health.Value = value; }
        #endregion

        public void ReceiveDamage(float damage)
        {
            Health -= damage;

            //La representacion debería de engancharse a un delegado que se lanza aquí
            //NumberPopup.Create(parent.gameObject.numberPopupsLocation, (int)damage, NumberPopupTypes.DAMAGE);
        }
    }
}