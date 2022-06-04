using System;
using UnityEngine;

namespace Autobattler.InventorySystem
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