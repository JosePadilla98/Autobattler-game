using System;
using UnityEngine;

namespace AutobattlerOld.Grid.Generic
{
    public class GridsController<T> : ScriptableObject
    {
        public Grid<T> leftGrid;
        public Grid<T> rightGrid;

        public void BuildNewItem(T item, Position pos)
        {
            var slot = GetItemContainer(pos);
            slot.BuildNewItem(item);
        }

        public ItemContainer<T> GetItemContainer(Position pos)
        {
            Grid<T> grid = pos.side == Side.LEFT ? leftGrid : rightGrid;
            ItemContainer<T>[] column = pos.column == Column.FRONT ? grid.front : grid.back;
            return column[(int)pos.heigh];
        }

        public Position GetItemPosition(T item)
        {
            var pos = leftGrid.GetItemPosition(item);
            if (pos.column != Column.NONE)
                return pos;

            pos = rightGrid.GetItemPosition(item);
            if (pos.column != Column.NONE)
                return pos;

            throw new Exception("The item is not on the grid");
        }

        public Grid<T> GetOppositeGrid(Side ReferenceSide)
        {
            if (ReferenceSide == Side.LEFT)
                return rightGrid;

            return leftGrid;
        }
    }
}
