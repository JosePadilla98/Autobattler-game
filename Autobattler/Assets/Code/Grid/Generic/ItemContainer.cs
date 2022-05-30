using System;
using System.Collections.Generic;
using UnityEngine;

namespace Autobattler.Grid.Generic
{
    public class ItemContainer<T> : ScriptableObject, IGridSlot<T>
    {
        public Grid<T> parent;
        public T myItem;
        public Action<T> OnNewItemBuilded;
        protected GridsController<T> Grandpa => parent.parent;

        public bool IsThereThisItem(T item)
        {
            if (myItem == null)
                return false;

            return EqualityComparer<T>.Default.Equals(item, myItem);
        }

        public void BuildNewItem(T item)
        {
            myItem = item;
            OnNewItemBuilded(item);
        }

        public virtual void AttachItem(T item)
        {
            myItem = item;
        }

        public virtual void UnnatachItem()
        {
            myItem = default(T);
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