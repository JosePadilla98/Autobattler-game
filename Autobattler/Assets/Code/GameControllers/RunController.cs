using System.Collections.Generic;
using Autobattler.Events;
using Autobattler.GameControllers.Combat;
using Autobattler.Grid;
using Autobattler.Grid.Generic;
using Autobattler.LevelSystem;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.GameControllers
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
