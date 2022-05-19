using Autobattler.Grid.CombatState;
using UnityEngine;

namespace Autobattler.GameControllers.Combat
{
    [CreateAssetMenu(fileName = "CombatState", menuName = "ScriptableObjects/CombatState", order = 0)]
    public class CombatState : ScriptableObject
    {
        public Battlefield_F battlefield;
        public FighterTeamsController teamsController;

        public void Init()
        {

        }
    }
}