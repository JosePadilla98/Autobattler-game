using Auttobattler.Backend.RunLogic.CombatState;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler.Frontend.ManagementState
{
    [RequireComponent(typeof(CombatSlot))]
    public class PlayerGridSlot : MonoBehaviour, IDropHandler
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
