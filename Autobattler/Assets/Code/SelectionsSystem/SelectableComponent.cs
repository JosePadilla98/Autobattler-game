﻿using System;
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

        public void WhenSelected()
        {
            image.color = selectedColor.color;
        }

        public void WhenUnselect()
        {
            image.color = unselectedColor;
        }

        /// <summary>
        /// Not call this from his controller!! 
        /// </summary>
        public void Select()
        {
            onSelected.Invoke(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Select();
        }
    }
}