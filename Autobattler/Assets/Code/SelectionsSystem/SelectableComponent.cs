using System;
using Autobattler.Configs.Color;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.SelectionsSystem
{
    public class SelectableComponent : MonoBehaviour, IPointerClickHandler
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

        public void OnPointerClick(PointerEventData eventData)
        {
            SendInfoThatImSelected();
        }

        private void OnDestroy()
        {
            onDestroy?.Invoke(this);
        }
    }
}