using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Auttobattler.Combat;
using Auttobattler.Scriptables;

namespace Auttobattler
{
    public class Battlefield : MonoBehaviour
    {
        public Grid leftGrid;
        public Grid rightGrid;

        #region SINGLETON

        private static Battlefield instance;
        public static Battlefield Instance
        {
            get => instance;
            set
            {
                if (instance != null)
                    throw new System.Exception("Must be only one");

                instance = value;
            }
        }

        #endregion 

        private void Awake()
        {
            Instance = this;
        }

        public void SummonUnit(UnitCombatInstance combatInstance, Position pos)
        {
            CombatSlot slot = GetCombatSlot(pos);
            UnitRepresentation unit = Instantiate(GameAssets.Instance.unitPrefab, slot.transform);
            unit.AttachCombatInstance(combatInstance);
            slot.unit = unit.CombatInstance;

            if (pos.side == Side.RIGHT)
            {
                unit.image.transform.localScale = new Vector3(-1, 1, 1);
                CombatController.Instance.rightTeam.Add(unit);
            }
            else
            {
                CombatController.Instance.leftTeam.Add(unit);
            }
        }

        public CombatSlot GetCombatSlot(Position pos)
        {
            Grid grid = (pos.side == Side.LEFT) ? leftGrid : rightGrid;
            CombatSlot[] column = (pos.column == Column.FRONT) ? grid.front : grid.back;
            return column[pos.heigh];
        }
    
        public Grid GetGrid(Side side)
        {
            return (side == Side.RIGHT) ? rightGrid : leftGrid;
        }
    }

    [System.Serializable]
    public class Grid
    {
        public CombatSlot[] front = new CombatSlot[3];
        public CombatSlot[] back = new CombatSlot[3];
        public Side side;

        public Position GetPosition(UnitCombatInstance c)
        {
            Position pos = SearchInColumn(front, c, Column.FRONT);

            if (pos.column == Column.NONE)
                pos = SearchInColumn(back, c, Column.BACK);

            return pos;
        }

        private Position SearchInColumn(CombatSlot[] column, UnitCombatInstance c, Column columnName)
        {
            for (int i = 0; i < column.Length; i++)
            {
                CombatSlot s = column[i];
                if (s.IsThereThisCreature(c))
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
