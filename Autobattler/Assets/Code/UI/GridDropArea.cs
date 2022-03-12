using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Auttobattler
{
    [RequireComponent(typeof(CombatSlot))]
    public class GridDropArea : MonoBehaviour, IDropHandler
    {
        public CreatureDragHandler item;
        private CombatSlot combatSlot;

        private void Awake()
        {
            combatSlot = GetComponent<CombatSlot>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                item = CreatureDragHandler.objBeingDraged;
                item.slot = this;
                combatSlot.creature = item.CreatureUI.Creature;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }
        }
    }
}
