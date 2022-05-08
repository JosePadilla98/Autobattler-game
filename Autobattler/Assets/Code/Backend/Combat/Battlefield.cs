using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Auttobattler.Combat;
using Auttobattler.Scriptables;

namespace Auttobattler
{
    public class Battlefield
    {
        public Grid leftGrid;
        public Grid rightGrid;

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
            leftGrid = new Grid(Side.LEFT);
            rightGrid = new Grid(Side.RIGHT);
        }

        public void SummonUnit(Fighter combatInstance, Position pos)
        {
            CombatSlot slot = GetCombatSlot(pos);
            slot.AttachUnit(combatInstance);

            if (pos.side == Side.RIGHT)
            {
                CombatController.Instance.enemyTeam.Add(combatInstance);
            }
            else
            {
                CombatController.Instance.playerTeam.Add(combatInstance);
            }
        }

        public CombatSlot GetCombatSlot(Position pos)
        {
            Grid grid = (pos.side == Side.LEFT) ? leftGrid : rightGrid;
            CombatSlot[] column = (pos.column == Column.FRONT) ? grid.front : grid.back;
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

        public Grid GetOppositeGrid(Side side)
        {
            if (side == Side.LEFT)
                return leftGrid;

            return rightGrid;
        }
    }

    public class Grid
    {
        public CombatSlot[] front = new CombatSlot[3];
        public CombatSlot[] back = new CombatSlot[3];
        public Side side;

        public Grid(Side side)
        {
            this.side = side;
        }

        public Position GetUnitPosition(Fighter combatInstance)
        {
            Position pos = SearchUnitInColumn(combatInstance, Column.FRONT);

            if (pos.column == Column.NONE)
                pos = SearchUnitInColumn(combatInstance, Column.BACK);

            return pos;
        }

        private Position SearchUnitInColumn(Fighter combatInstance, Column columnName)
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
                if (combatSlot.IsThereThisCreature(combatInstance))
                {
                    return new Position(i, columnName, side);
                }
            }

            return new Position(0, Column.NONE, side);
        }
    }

    #region POSITION INFO

    public enum Column
    {
        FRONT, BACK, NONE
    }

    public enum Side
    {
        LEFT, RIGHT
    }

    public struct Position
    {
        public int heigh;
        public Column column;
        public Side side;

        public Position(int heigh, Column column, Side side)
        {
            this.heigh = heigh;
            this.column = column;
            this.side = side;
        }
    }

    #endregion
}
