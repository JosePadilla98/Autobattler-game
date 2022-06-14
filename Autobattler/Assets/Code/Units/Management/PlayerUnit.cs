namespace Autobattler.Units.Management
{
    public class PlayerUnit : Unit
    {
        public ExperiencieModule expModule;

        public PlayerUnit(UnitBuild blueprint, LevelsBonificationsModel lvsBonificationsModel)
        {
            UnitInitialization(blueprint);
            expModule = new ExperiencieModule(this, lvsBonificationsModel);
        }
    }
}