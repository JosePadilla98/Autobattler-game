using Autobattler.Units.Management;

namespace Autobattler.Units.Combat.CombatSystems
{
    public class HealthSystem : CombatSystem
    {
        public HealthSystem(Fighter parent) : base(parent)
        {
        }

        public void ReceiveDamage(float damage)
        {
            CurrentHealth -= damage;

            //La representacion debería de engancharse a un delegado que se lanza aquí
            //NumberPopup.Create(parent.gameObject.numberPopupsLocation, (int)damage, NumberPopupTypes.DAMAGE);
        }

        #region Properties

        public float MaxHealth => parent.StatsContainer.GetStatValue(StatsNames.HEALTH);

        public float CurrentHealth
        {
            get => parent.combatValues.currentHealth.Value;
            set => parent.combatValues.currentHealth.Value = value;
        }

        #endregion
    }
}