using Autobattler.ScriptableCollections;
using UnityEngine;

namespace Autobattler.RunData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public UnitsCollection teamInGrid;
        public UnitsCollection teamInBench;
    }
}