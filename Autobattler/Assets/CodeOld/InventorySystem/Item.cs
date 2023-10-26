using System;
using UnityEngine;

namespace AutobattlerOld.InventorySystem
{
    [Serializable]
    public class Item
    {
        public ItemScriptable Scriptable;

        public Item(ItemScriptable scriptable)
        {
            Scriptable = scriptable;
        }
    }
}