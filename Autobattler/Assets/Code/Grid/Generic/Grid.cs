﻿using UnityEngine;

namespace Autobattler.Grid.Generic
{
    public class Grid<T> : ScriptableObject
    {
        public GridsController<T> parent;
        public ItemContainer<T>[] back;
        public ItemContainer<T>[] front;
        public Side side;

        public Position GetItemPosition(T item)
        {
            var pos = SearchItemInColumn(item, Column.FRONT);

            if (pos.column == Column.NONE) //Has not find anything, search in the other column
                pos = SearchItemInColumn(item, Column.BACK);

            return pos;
        }

        private Position SearchItemInColumn(T item, Column columnName)
        {
            ItemContainer<T>[] column = null;
            if (columnName == Column.FRONT)
                column = front;
            else if (columnName == Column.BACK)
                column = back;

            for (var i = 0; i < column.Length; i++)
            {
                var gridSlot = column[i];
                if (gridSlot.IsThereThisItem(item)) return new Position(i, columnName, side);
            }
            return new Position(0, Column.NONE, side);
        }
    }
}