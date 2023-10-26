using AutobattlerOld.ScriptableCollections;
using UnityEngine;

namespace AutobattlerOld.RunData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public UnitsCollection teamInGrid;
        public UnitsCollection teamInBench;
        public UnitsCollection team;

        public void Init()
        {
            teamInGrid.Collection.Clear();
            teamInBench.Collection.Clear();
            team.Collection.Clear();
        }
    }
}