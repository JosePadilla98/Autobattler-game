using AutobattlerOld.InfoPanel;
using UnityEngine;

namespace AutobattlerOld.InventorySystem
{
    public abstract class ItemScriptable : ScriptableObject
    {
        public Sprite sprite;

        [Space(20)]
        public TextPanelData info;

        public abstract void OnClick(ItemView itemView);

        public abstract TextPanelData GetDescription();
    }
}