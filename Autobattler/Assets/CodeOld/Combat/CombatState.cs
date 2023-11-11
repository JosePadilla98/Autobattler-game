using AutobattlerOld.Events;
using AutobattlerOld.Grid.Logic;
using UnityEngine;

namespace AutobattlerOld.GameControllers.Combat
{
    [CreateAssetMenu(
        fileName = "CombatState",
        menuName = "ScriptableObjects/CombatState",
        order = 0
    )]
    public class CombatState : ScriptableObject
    {
        public Battlefield_F battlefield;
        public FighterTeamsController teamsController;

        public void Init() { }

        public void Refresh()
        {
            teamsController.Refresh();
        }
    }
}
