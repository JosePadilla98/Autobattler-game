namespace AutobattlerOld.Units.Combat.CombatSystems
{
    public class DefenseSystem : CombatSystem
    {
        private float Defense =>
            parent.StatsContainer.GetStatValue(StatsNames.DEFENSE);

        public DefenseSystem(Fighter parent)
            : base(parent) { }

        public void BeAttacked(DamageData damageData)
        {
            var damage = damageData.value / Defense;
            parent.healthSys.ReceiveDamage(damage);
        }
    }
}
