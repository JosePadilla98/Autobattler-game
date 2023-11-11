namespace AutobattlerOld.DragAndDrop
{
    public static class ObjectBeingDragged
    {
        public static DraggableComponent obj;

        public static bool dragHasBeenCanceled;

        public static void CancelDragging()
        {
            if (obj == null)
                return;

            obj.EndDrag();
            dragHasBeenCanceled = true;
        }
    }
}