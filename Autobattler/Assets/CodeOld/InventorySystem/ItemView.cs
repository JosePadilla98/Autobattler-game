using System;
using AutobattlerOld.Events;
using AutobattlerOld.InfoPanel;
using AutobattlerOld.Units.Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AutobattlerOld.InventorySystem
{
    public class ItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private Image image;

        public Item item;

        public UnityEvent<TextPanelData> onPointerEnterEvent;
        public UnityEvent onPointerExitEvent;
        public Action<ItemView> beforeDestroy;

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
            if (mouseIsOverMe)
                onPointerExitEvent.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            item.Scriptable.OnClick(this);
        }

        public void DestroyItem()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            beforeDestroy?.Invoke(this);
        }
    }
}