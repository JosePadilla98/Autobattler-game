namespace Auttobattler.Backend
{
    public static class InstancesProvider
    {
        public static GridsController<Fighter> GetBattlefield()
        {
            return App.Instance.Run.CombatState.Battlefield;
        }
    }
}
