namespace Autobattler.Grid.Generic
{
    public interface IGridSlot<T>
    {
        public Side GetSide();
        public T GetItem();
        public bool IsThereThisItem(T item);
        public void AttachItem(T item);
    }
}