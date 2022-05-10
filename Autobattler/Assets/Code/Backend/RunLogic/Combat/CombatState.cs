using Assets.Code.Backend.RunLogic.Combat.Fighter;
using Assets.Code.Backend.RunLogic.GenericGrid;
using Auttobattler.Backend.RunLogic.Management;

namespace Auttobattler.Backend.RunLogic.Combat
{
    public class CombatState
    {
        private bool isActive;
        private TeamsController teamsController;
        private GridsController<Fighter> gridsController;

        public void Init(GridsController<Unit> gridsData)
        {

        }

        public void ConvertUnitsIntoFighters()
        {

        }
    }
}
