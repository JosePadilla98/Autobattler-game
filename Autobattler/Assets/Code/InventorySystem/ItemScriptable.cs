using UnityEngine;

namespace Autobattler.InventorySystem
{
    public abstract class ItemScriptable : ScriptableObject
    {
        public abstract void OnClick();
    }
}