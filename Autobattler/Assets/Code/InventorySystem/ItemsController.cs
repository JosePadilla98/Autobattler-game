using Autobattler.ScriptableCollections;
using UnityEngine;

namespace Autobattler.InventorySystem
{
    [CreateAssetMenu(fileName = "LevelSystem", menuName = "ScriptableObjects/Inventory/Inventory")]
    public class ItemsController : ScriptableObject
    {
        public ItemsColecttions itemsInBag;

        
    }
}