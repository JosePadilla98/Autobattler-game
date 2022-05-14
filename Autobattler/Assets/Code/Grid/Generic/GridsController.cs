//using System;

//namespace Autobattler.Grid.Generic
//{
//    public class GridsController<T> 
//    {
//        public Grid<T> leftGrid;
//        public Grid<T> rightGrid;

//        public void AttachItem(T item, Position pos)
//        {
//            var slot = GetItemContainer(pos);
//            slot.AttachItem(item);
//        }

//        public IGridSlot<T> GetItemContainer(Position pos)
//        {
//            var grid = pos.side == Side.LEFT ? leftGrid : rightGrid;
//            var column = pos.column == Column.FRONT ? grid.front : grid.back;
//            return column[pos.heigh];
//        }

//        public Position GetItemPosition(T item)
//        {
//            var pos = leftGrid.GetItemPosition(item);
//            if (pos.column != Column.NONE)
//                return pos;

//            pos = rightGrid.GetItemPosition(item);
//            if (pos.column != Column.NONE)
//                return pos;

//            throw new Exception("The item is not on the grid");
//        }

//        public Grid<T> GetOppositeGrid(Side side)
//        {
//            if (side == Side.LEFT)
//                return leftGrid;

//            return rightGrid;
//        }
//    }
//}