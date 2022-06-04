using Autobattler.InventorySystem;
using Autobattler.ScriptableCollections;
using UnityEngine;

namespace Autobattler.GameControllers
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public UnitsCollection teamInGrid;
        public UnitsCollection teamInBench;
    }
}