using System.Collections.Generic;
using AutobattlerOld.InventorySystem;
using UnityEngine;

namespace AutobattlerOld.ScriptableCollections
{
    [CreateAssetMenu(fileName = "ItemsColecttions", menuName = "ScriptableObjects/Collections/Items")]
    public class ItemsCollection : ScriptableObject
    {
        private List<Item> collection;

        public List<Item> Collection
        {
            get
            {
                if (collection == null)
                    collection = new();

                return collection;
            }
        }
    }
}