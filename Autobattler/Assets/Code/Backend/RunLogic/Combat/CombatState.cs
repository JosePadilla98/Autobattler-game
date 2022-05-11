
using System;

namespace Auttobattler.Backend
{
    public class CombatState
    {
        private bool isActive;
        private TeamsController teamsController;
        private GridsController<Fighter> battlefield;
        public GridsController<Fighter> Battlefield { get => battlefield; }

        private Run parent;

        public void Init(Run parent, GridsController<Unit> gridsData)
        {
            this.parent = parent;
        }

        public void ConvertUnitsIntoFighters()
        {

        }
    }
}
