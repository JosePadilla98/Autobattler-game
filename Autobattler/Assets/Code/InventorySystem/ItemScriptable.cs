using Autobattler.InfoPanel;
using UnityEngine;

namespace Autobattler.InventorySystem
{
    public abstract class ItemScriptable : ScriptableObject
    {
        public Sprite sprite;

        [Space(20)]
        public TextPanelData info;

        public abstract void OnClick();

        public abstract TextPanelData GetDescription();
    }
}