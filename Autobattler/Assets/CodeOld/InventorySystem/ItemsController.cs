using System.Collections.Generic;
using AutobattlerOld.Events;
using AutobattlerOld.ScriptableCollections;
using UnityEngine;

namespace AutobattlerOld.InventorySystem
{
    [CreateAssetMenu(fileName = "ItemsController", menuName = "ScriptableObjects/Inventory/ItemsController")]
    public class ItemsController : ScriptableObject
    {
        public ItemsCollection itemsInBag;

        [SerializeField]
        private GameEvent_Item onItemCreated;

        [Space(20)]
        [SerializeField]
        private List<ItemScriptable> initialItems;

        public void AddNewItem(Item item)
        {
            itemsInBag.Collection.Add(item);
            onItemCreated.Raise(item);
        }

        public void Init()
        {
            itemsInBag.Collection.Clear();
            CreateInitialItems();
        }

        private void CreateInitialItems()
        {
            foreach (var scriptable in initialItems)
            {
                Item item = new Item(scriptable);
                AddNewItem(item);
            }
        }
    }
}