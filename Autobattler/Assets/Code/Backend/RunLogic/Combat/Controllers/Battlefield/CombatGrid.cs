using System;

namespace Auttobattler.Backend.RunLogic.Combat
{
    public class CombatGrid
    {
        public CombatSlot[] front = new CombatSlot[3];
        public CombatSlot[] back = new CombatSlot[3];
        public Side side;

        public CombatGrid(Side side)
        {
            this.side = side;
        }

        public Position GetUnitPosition(Fighter fighter)
        {
            Position pos = SearchUnitInColumn(fighter, Column.FRONT);

            if (pos.column == Column.NONE)
                pos = SearchUnitInColumn(fighter, Column.BACK);

            return pos;
        }

        private Position SearchUnitInColumn(Fighter fighter, Column columnName)
        {
            CombatSlot[] column = null;
            if (columnName == Column.FRONT)
                column = front;
            else if (columnName == Column.BACK)
                column = back;
            else
                throw new Exception("What the hell are you doing?");

            for (int i = 0; i < column.Length; i++)
            {
                CombatSlot combatSlot = column[i];
                if (combatSlot.IsThereThisFighter(fighter))
                {
                    return new Position(i, columnName, side);
                }
            }

            return new Position(0, Column.NONE, side);
        }
    }
}