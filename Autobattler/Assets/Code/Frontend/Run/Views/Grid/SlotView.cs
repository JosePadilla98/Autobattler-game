using UnityEngine;
using Auttobattler.Backend;

namespace Auttobattler.Frontend
{
    public class SlotView<T> : MonoBehaviour, IGridSlot<T>
    {
        public void AttachItem(T item)
        {
            throw new System.NotImplementedException();
        }

        public T GetItem()
        {
            throw new System.NotImplementedException();
        }

        public Side GetSide()
        {
            throw new System.NotImplementedException();
        }

        public bool IsThereThisItem(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
