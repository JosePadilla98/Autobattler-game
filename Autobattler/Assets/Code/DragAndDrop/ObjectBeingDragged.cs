using UnityEngine;

namespace Autobattler.DragAndDrop
{
    public static class ObjectBeingDragged
    {
        public static DraggableComponent obj;

        public static void CancelDragging(){
            if(obj == null)
                return;

            obj.EndDrag();
        }
    }
}