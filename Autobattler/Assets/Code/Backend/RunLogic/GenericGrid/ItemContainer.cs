using Auttobattler.Backend.RunLogic;
using System.Collections.Generic;

namespace Assets.Code.Backend.RunLogic.GenericGrid
{
    public class ItemContainer<T> : IGridSlot<T>
    {
        private T myItem;
        private Grid<T> parent;

        public ItemContainer(Grid<T> parent)
        {
            this.parent = parent;
        }

        public bool IsThereThisItem(T item)
        {
            if (myItem == null)
                return false;

            return EqualityComparer<T>.Default.Equals(item, myItem);
        }

        public void AttachItem(T item)
        {
            myItem = item;
        }

        public Side GetSide()
        {
            return parent.side;
        }

        public T GetItem()
        {
            return myItem;
        }
    }
}
