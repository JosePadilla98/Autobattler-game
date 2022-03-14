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
            Action<BuildedUnitBlueprint[], CombatSlot[]> action = (blueprintColum, SummonLocationColumn) =>
            {
                for (int i = 0; i < blueprintColum.Length; i++)
                {
                    BuildedUnitBlueprint blueprint = blueprintColum[i];

                    if (blueprint == null)
                        continue;

                    SummonUnit(blueprint, SummonLocationColumn[i], Side.RIGHT);
                }
            };

            action(level.frontColumn, rightGrid.front);
            action(level.backColumn, rightGrid.back);
        }

        public void SummonUnit(BuildedUnitBlueprint blueprint, CombatSlot slot, Side side)
        {
            Unit unit = Instantiate(unitPrefab, slot.transform);
            unit.CreateCombatInstance(new BuildedUnit(blueprint, blueprint.level), side);

            if (side == Side.RIGHT)
            {
                unit.image.transform.localRotation = Quaternion.Euler(0, 180, 0);
                CombatController.Instance.rightTeam.Add(unit);
            }
            else
            {
                CombatController.Instance.leftTeam.Add(unit);
            }

            slot.unit = unit.combatInstance;
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
