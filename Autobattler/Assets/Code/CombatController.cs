using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    [RequireComponent(typeof(Battlefield))]
    public class CombatController : MonoBehaviour
    {
        public CreatureInCombat[] c;
        public List<CreatureInCombat> leftTeam;

        private void FixedUpdate()
        {

        }
    }
}