using Auttobattler.Backend.Run.CombatState;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler.Frontend.ManagementState
{
    [RequireComponent(typeof(CombatSlot))]
    public class PlayerGridSlot : GridSlotRepresentation, IDropHandler
    {
        [HideInInspector]
        public UnitDragHandler item;

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                item = UnitDragHandler.objBeingDraged;
                item.dropArea = this;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                item.Rect.anchoredPosition = Vector3.zero;
            }
        }
    }
}
