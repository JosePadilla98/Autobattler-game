using System.Collections.Generic;
using AutobattlerOld.Events;
using AutobattlerOld.GameControllers.Combat;
using AutobattlerOld.Grid;
using AutobattlerOld.Grid.Generic;
using AutobattlerOld.Units.Combat;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.GameControllers
{
    [CreateAssetMenu(fileName = "RunController", menuName = "ScriptableObjects/RunController")]
    public class RunController : ScriptableObject
    {
        [Space(20)]
        public ManagementState managementState;

        [Space(20)]
        public CombatState combatState;
        public GameEvent combatStarted;

        public void Init()
        {
            RandomController.Init();
            managementState.Init();
        }

        public void InitCombat()
        {
            PassManagementDataToCombatState();
            combatState.Init();
            combatStarted.Raise();
        }

        public void PassManagementDataToCombatState()
        {
            //Pass player units
            List<Unit> playerUnits = managementState.playerData.teamInGrid.Collection;
            List<Fighter> playerFighters = combatState.teamsController.playerFighters.Collection;

            GridsController<Unit> battlefield_U = managementState.managementBattlefield;
            GridsController<Fighter> battlefield_F = combatState.battlefield;

            foreach (Unit unit in playerUnits)
            {
                Fighter fighter = new Fighter(unit);
                playerFighters.Add(fighter);

                Position pos = battlefield_U.GetItemPosition(unit);
                battlefield_F.BuildNewItem(fighter, pos);
            }

            //Pass enemies
            List<Unit> enemyUnits = managementState.enemies.Collection;
            List<Fighter> enemyFighters = combatState.teamsController.enemies.Collection;

            foreach (Unit unit in enemyUnits)
            {
                Fighter fighter = new Fighter(unit);
                enemyFighters.Add(fighter);

                Position pos = battlefield_U.GetItemPosition(unit);
                battlefield_F.BuildNewItem(fighter, pos);
            }
        }
    }
}
