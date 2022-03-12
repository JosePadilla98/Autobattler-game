using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class Battlefield : MonoBehaviour
    {
        public Grid left;
        public Grid right;

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
    }

    [System.Serializable]
    public class Grid
    {
        public CombatSlot[] front = new CombatSlot[3];
        public CombatSlot[] back = new CombatSlot[3];
        public Side side;

        private Battlefield parent;
        public Battlefield Battlefield { get => parent; }

        public Grid(Battlefield parent)
        {
            this.parent = parent;
        }

        public Position GetPosition(CreatureInCombat c)
        {
            Position pos = SearchInColumn(front, c, GridColumn.FRONT);

            if (pos.column == GridColumn.NONE)
                pos = SearchInColumn(back, c, GridColumn.BACK);

            return pos;
        }

        private Position SearchInColumn(CombatSlot[] column, CreatureInCombat c, GridColumn columnName)
        {
            for (int i = 0; i < column.Length; i++)
            {
                CombatSlot s = column[i];
                if (s.IsThereThisCreature(c))
                {
                    return new Position(i, columnName, side);
                }
            }

            return new Position(0, GridColumn.NONE, side);
        }
    }

    public enum GridColumn
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
        public GridColumn column;
        public Side side;

        public Position(int heigh, GridColumn column, Side side)
        {
            this.heigh = heigh;
            this.column = column;
            this.side = side;
        }
    }
}
