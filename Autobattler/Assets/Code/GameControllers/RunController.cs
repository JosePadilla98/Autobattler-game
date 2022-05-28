using System.Collections.Generic;
using Autobattler.Events;
using Autobattler.GameControllers.Combat;
using Autobattler.Grid;
using Autobattler.Grid.Generic;
using Autobattler.LevelSystem;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.GameControllers
{
    [CreateAssetMenu(fileName = "RunController", menuName = "ScriptableObjects/RunController")]
    public class RunController : ScriptableObject
    {
        public LevelsSystem levelsSystem;
        public ManagementStateData managementData;

        public CombatState combatState;
        public GameEvent combatStarted;

        public void Init()
        {
            levelsSystem.Init();
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
            List<_Unit> playerUnits = managementData.playerData.teamInGrid.Collection;
            List<Fighter> playerFighters = combatState.teamsController.playerFighters.Collection;

            GridsController<_Unit> battlefield_U = managementData.managementBattlefield;
            GridsController<Fighter> battlefield_F = combatState.battlefield;

            foreach (_Unit unit in playerUnits)
            {
                Fighter fighter = new Fighter(unit);
                playerFighters.Add(fighter);

                Position pos = battlefield_U.GetItemPosition(unit);
                battlefield_F.BuildNewItem(fighter, pos);
            }

            //Pass enemies
            List<_Unit> enemyUnits = managementData.enemies.Collection;
            List<Fighter> enemyFighters = combatState.teamsController.enemies.Collection;

            foreach (_Unit unit in enemyUnits)
            {
                Fighter fighter = new Fighter(unit);
                enemyFighters.Add(fighter);

                Position pos = battlefield_U.GetItemPosition(unit);
                battlefield_F.BuildNewItem(fighter, pos);
            }
        }
    }
}
