using Auttobattler.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Ultimates
{
    [CreateAssetMenu(fileName = "IcyWind", menuName = "ScriptableObjects/Ultimates/Yeti/IcyWind")]
    public class IcyWind_Scriptable : UltimateScriptable
    {
        public AttackData attackData;

        public override Ultimate GetUltimate()
        {
            return new IcyWindy(this);
        }
    }

    public class IcyWindy : Ultimate
    {
        public AttackData attackData;

        public IcyWindy(IcyWind_Scriptable scriptable)
        {
            attackData = (AttackData)scriptable.attackData.Clone();
        }

        public override void Cast(UnitCombatInstance instance)
        {
            instance.LaunchAttack(attackData.type, attackData.Power);
            Debug.Log("Casted");
        }

        public override string GetName()
        {
            return "Icy wind";
        }
    }
}
