using Autobattler.InventorySystem.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Autobattler.InventorySystem
{
    public class InventoryItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public ItemScriptable item;

        public void OnPointerClick(PointerEventData eventData)
        {
            item.OnClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}