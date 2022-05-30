using System;
using Autobattler.Events;
using Autobattler.InfoPanel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.InventorySystem
{
    public class ItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Image image;

        public Item item;

        public UnityEvent<TextPanelData> onPointerEnterEvent;
        public UnityEvent onPointerExitEvent;

        private bool mouseIsOverMe;
        public void InyectDependencies(Item item)
        {
            this.item = item;
            image.sprite = item.Scriptable.sprite;
        }

        public TextPanelData GetDescription()
        {
            return item.Scriptable.GetDescription();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mouseIsOverMe = true;
            onPointerEnterEvent.Invoke(GetDescription());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouseIsOverMe = false;
            onPointerExitEvent.Invoke();
        }

        private void OnDisable()
        {
            if(mouseIsOverMe)
                onPointerExitEvent.Invoke();
        }
    }
}