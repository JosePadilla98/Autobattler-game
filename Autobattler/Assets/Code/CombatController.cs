using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    [RequireComponent(typeof(Battlefield))]
    public class CombatController : MonoBehaviour
    {
        public List<UnitCombatInstance> leftTeam;

        private void FixedUpdate()
        {

        }
    }
}