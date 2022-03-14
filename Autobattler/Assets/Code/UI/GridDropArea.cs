using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    [RequireComponent(typeof(CombatSlot))]
    public class GridDropArea : MonoBehaviour, IDropHandler
    {
        public UnitDragHandler item;
        private CombatSlot combatSlot;
        public CombatSlot CombatSlot { get => combatSlot;}

        private void Awake()
        {
            combatSlot = GetComponent<CombatSlot>();
        }

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
