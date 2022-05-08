using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    [RequireComponent(typeof(CombatSlot))]
    public class GridDropArea : MonoBehaviour, IDropHandler
    {
        [HideInInspector]
        public UnitDragHandler item;

        public PlayerUnitRepresentation playerUnitRepresentation;

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
