
namespace Auttobattler.Backend.Run.CombatState
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
