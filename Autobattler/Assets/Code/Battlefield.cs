using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Auttobattler.Combat;
using Auttobattler.Scriptables;

namespace Auttobattler
{
    public class Battlefield : MonoBehaviour
    {
        public Grid left;
        public Grid right;

        public Unit unitPrefab;

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

        public void SummonEnemies(Level level)
        {
            for (int i = 0; i < level.frontRow.Length; i++)
            {
                BuildedUnitBlueprint blueprint = level.frontRow[i];

                if (blueprint == null)
                    continue;

                SummonUnit(blueprint, right.front[i], UnitType.ENEMY);
            }
        }

        public void SummonUnit(BuildedUnitBlueprint blueprint, CombatSlot slot, UnitType type)
        {
            Unit unit = Instantiate(unitPrefab, slot.transform);
            unit.build = new BuildedUnit(blueprint);
            unit.CreateCombatInstance();

            if (type == UnitType.ENEMY)
                unit.image.transform.localRotation = Quaternion.Euler(0, 180, 0);

            slot.unit = unit.combatInstance;
        }
    }

    public enum UnitType
    {
        FRIEND, ENEMY
    }

    [System.Serializable]
    public class Grid
    {
        public CombatSlot[] front = new CombatSlot[3];
        public CombatSlot[] back = new CombatSlot[3];
        public Side side;

        public Position GetPosition(UnitCombatInstance c)
        {
            Position pos = SearchInColumn(front, c, GridColumn.FRONT);

            if (pos.column == GridColumn.NONE)
                pos = SearchInColumn(back, c, GridColumn.BACK);

            return pos;
        }

        private Position SearchInColumn(CombatSlot[] column, UnitCombatInstance c, GridColumn columnName)
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
