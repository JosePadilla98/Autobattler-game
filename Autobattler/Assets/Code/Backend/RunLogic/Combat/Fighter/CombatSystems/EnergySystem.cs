
namespace Auttobattler.Backend.RunLogic.Combat
{
    public struct EnergyCostData
    {
        public float vigor;
        public float mana;
    }

    public class EnergySystem : CombatSystem
    {
        public EnergySystem(Fighter parent) : base(parent) { }
       

        public bool TryPayCost(EnergyCostData cost)
        {
            return true;
        }
    }

    public class EnergySubsystem
    {

    }
}