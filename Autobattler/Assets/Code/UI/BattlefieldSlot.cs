using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace auttobattler
{
    public class BattlefieldSlot : MonoBehaviour, IDropHandler
    {
        public CreatureDragHandler item;

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                item = CreatureDragHandler.objBeingDraged;
                item.slot = this;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }
        }

    }
}
