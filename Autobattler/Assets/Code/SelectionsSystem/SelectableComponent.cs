using System;
using Autobattler.Configs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.SelectionSystem
{
    public class SelectableComponent : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private ColorModel selectedColor;

        private Color unselectedColor;

        public Action<SelectableComponent> onSelected;
        public MonoBehaviour target;

        private void Awake()
        {
            unselectedColor = image.color;
        }

        public void Select()
        {
            image.color = selectedColor.color;
        }

        public void Unselect()
        {
            image.color = unselectedColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            onSelected.Invoke(this);
        }
    }
}