using Autobattler.Grid.ManagementState;
using UnityEngine;

namespace Autobattler.States
{
    [CreateAssetMenu(fileName = "CombatState", menuName = "ScriptableObjects/CombatState", order = 0)]
    public class CombatState : ScriptableObject
    {
        public Battlefield_F battlefield;
        public TeamsController teamsController;

        public void Init()
        {

        }
    }
}