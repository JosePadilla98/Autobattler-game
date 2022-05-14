using System.Collections.Generic;
using UnityEngine;

namespace Autobattler.Grid.Generic
{
    public abstract class ItemContainer<T1> : MonoBehaviour, IGridSlot<T1>
    {
        private T1 myItem;

        public bool IsThereThisItem(T1 item)
        {
            if (myItem == null)
                return false;

            return EqualityComparer<T1>.Default.Equals(item, myItem);
        }

        public void AttachItem(T1 item)
        {
            myItem = item;
        }

        public Side GetSide()
        {
            throw new System.NotImplementedException();
        }

        public T1 GetItem()
        {
            return myItem;
        }
    }
}