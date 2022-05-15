using UnityEngine;

namespace Autobattler.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public UnitsCollection teamInGrid;
        public UnitsCollection teamInBench;
    }
}