using System;
using System.Collections.Generic;
using Autobattler.Screens;
using Autobattler.SelectionSystem;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Autobattler.EditUnit
{
    public class SpritesList : MonoBehaviour
    {
        [SerializeField]
        private UnlockedUnitsSprites spritesUnlocked;
        [SerializeField]
        private SelectableComponent spriteViewPrefab;
        [SerializeField] 
        private Transform spritesTransform;
        [SerializeField] 
        private List<SelectableComponent> children;
        [SerializeField]
        private UnityEvent<Sprite> onSpriteSelected;

        public void Enable(Unit unit)
        {
            foreach (var sprite in spritesUnlocked.sprites)
            {
                SelectableComponent s = Instantiate<SelectableComponent>(spriteViewPrefab, spritesTransform);
                Image selectableImage = s.target as Image;
                selectableImage.sprite = sprite;

                if (unit.sprite == sprite)
                    s.WhenSelected();

                children.Add(s);
                s.onSelected += OnChildSelected;
            }
        }

        public void OnDisable()
        {
            for (int i = children.Count -1; i > 0; i--)
            {
                var selectableChild = children[i];
                selectableChild.onSelected -= OnChildSelected;
                Destroy(selectableChild.gameObject);
            }
        }

        private void OnChildSelected(MonoBehaviour mono)
        {
            Sprite selectedSprite = ((mono as SelectableComponent).target as Image).sprite;
            onSpriteSelected.Invoke(selectedSprite);
        }
    }
}