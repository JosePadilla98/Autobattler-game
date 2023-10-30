using AutobattlerOld.Units.Management;

namespace AutobattlerOld.Units.Combat.CombatSystems
{
    public class DefenseSystem : CombatSystem
    {
        public DefenseSystem(Fighter parent)
            : base(parent) { }

        public void BeAttacked(DamageData damageData)
        {
            var defenseValue =
                damageData.type == DamageType.PHYSICAL ? PhysicalDefense : MagicalDefense;
            var damage = damageData.value / defenseValue;
            parent.healthSys.ReceiveDamage(damage);
        }

        #region Properties

        public float PhysicalDefense =>
            parent.StatsContainer.GetStatValue(OldStatsNames.PHYSICAL_DEFENSE);
        public float MagicalDefense =>
            parent.StatsContainer.GetStatValue(OldStatsNames.MAGICAL_DEFENSE);

        #endregion
    }
}
