using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public struct EnergyCostData
    {
        public float vigor;
        public float mana;
    }

    public class EnergySystem : CombatSystem
    {
        public EnergySystem(UnitCombatInstance parent) : base(parent) { }
       

        public bool TryPayCost(EnergyCostData cost)
        {
            return true;
        }
    }

    public class EnergySubsystem
    {

    }
}
