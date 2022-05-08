using Auttobattler.Backend.Run;
using Auttobattler.Backend.Run.CombatState;
using System;

namespace Assets.Code.Backend.Run.CombatState.Controllers.Battlefield
{
    public class Battlefield
    {
        public CombatGrid leftGrid;
        public CombatGrid rightGrid;

        public Action<Fighter, CombatSlot> OnUnitSummoned;

        #region SINGLETON
        private static Battlefield instance;
        public static Battlefield Instance
        {
            get
            {
                if (instance == null)
                    instance = new Battlefield();

                return instance;
            }
        }
        #endregion 

        public Battlefield()
        {
            leftGrid = new CombatGrid(Side.LEFT);
            rightGrid = new CombatGrid(Side.RIGHT);
        }

        public void AttachUnit(Fighter combatInstance, Position pos)
        {
            CombatSlot slot = GetCombatSlot(pos);
            slot.AttachUnit(combatInstance);

            if (pos.side == Side.RIGHT)
            {
                TeamsController.Instance.enemyTeam.Add(combatInstance);
            }
            else
            {
                TeamsController.Instance.playerTeam.Add(combatInstance);
            }
        }

        public CombatSlot GetCombatSlot(Position pos)
        {
            CombatGrid grid = pos.side == Side.LEFT ? leftGrid : rightGrid;
            CombatSlot[] column = pos.column == Column.FRONT ? grid.front : grid.back;
            return column[pos.heigh];
        }

        public Position GetFighterPosition(Fighter unitCombatInstance)
        {
            Position pos = leftGrid.GetUnitPosition(unitCombatInstance);
            if (pos.column != Column.NONE)
                return pos;

            pos = rightGrid.GetUnitPosition(unitCombatInstance);
            if (pos.column != Column.NONE)
                return pos;

            throw new Exception("Something is wrong");
        }

        public CombatGrid GetOppositeGrid(Side side)
        {
            if (side == Side.LEFT)
                return leftGrid;

            return rightGrid;
        }
    }
}
