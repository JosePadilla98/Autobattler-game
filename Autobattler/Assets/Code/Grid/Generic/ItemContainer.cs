using System;
using System.Collections.Generic;
using UnityEngine;

namespace Autobattler.Grid.Generic
{
    public class ItemContainer<T> : ScriptableObject
    {
        public Grid<T> parent;
        private T myItem;

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