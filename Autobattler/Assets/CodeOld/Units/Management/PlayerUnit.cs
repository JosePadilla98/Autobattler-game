using AutobattlerOld.ExpModule;

namespace AutobattlerOld.Units.Management
{
    public class PlayerUnit : Unit
    {
        public ExperiencieModule expModule;

        public PlayerUnit(UnitBuild blueprint, UnitsLevellingModel lvsBonifications)
        {
            UnitInitialization(blueprint);
            expModule = new ExperiencieModule(this, lvsBonifications);
        }
    }
}