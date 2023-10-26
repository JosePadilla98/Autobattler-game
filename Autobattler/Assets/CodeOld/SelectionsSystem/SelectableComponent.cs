using System;
using AutobattlerOld.Configs.Color;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AutobattlerOld.SelectionsSystem
{
    public class SelectableComponent : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private ColorModel selectedColor;

        private Color unselectedColor;

        public Action<SelectableComponent> onSelected;
        public Action<SelectableComponent> onDestroy;
        public MonoBehaviour target;

        private void Awake()
        {
            unselectedColor = image.color;
        }

        public void Select()
        {
            image.color = selectedColor.color;
        }

        public void Deselect()
        {
            image.color = unselectedColor;
        }

        /// <summary>
        /// Not call this from his controller!! 
        /// </summary>
        public void SendInfoThatImSelected()
        {
            onSelected.Invoke(this);
        }

        private void OnDestroy()
        {
            onDestroy?.Invoke(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SendInfoThatImSelected();
        }
    }
}