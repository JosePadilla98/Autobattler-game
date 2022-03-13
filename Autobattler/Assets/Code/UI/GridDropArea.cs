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

        private void Awake()
        {
            combatSlot = GetComponent<CombatSlot>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                item = UnitDragHandler.objBeingDraged;
                item.slot = this;
                //combatSlot.unit = item.CreatureUI.Creature;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }
        }
    }
}
