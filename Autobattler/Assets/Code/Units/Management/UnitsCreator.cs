using System;
using Autobattler.Events;
using Autobattler.GameControllers;
using Autobattler.Grid;
using Autobattler.ScriptableCollections;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Units
{
    [CreateAssetMenu(fileName = "UnitsCreator", menuName = "ScriptableObjects/UnitsCreator")]
    public class UnitsCreator : ScriptableObject
    {
        [SerializeField]
        private GameEvent_Unit playerUnitCreated;
        [SerializeField]
        private GameEvent_Unit newPlayerUnitBuildInInventory;

        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private UnitsCollection enemies;
        [SerializeField] 
        private UnitBuild defaultUnitBuild;

        public Unit CreateUnitInGrid(UnitBuild blueprint, Side side)
        {
            var unit = new Unit(blueprint);

            if (side == Side.LEFT)
            {
                playerData.teamInGrid.Collection.Add(unit);
                playerUnitCreated.Raise(unit);
            }
            else
            {
                enemies.Collection.Add(unit);
            }

            return unit;
        }

        public Unit CreateNewPlayerUnit()
        {
            var unit = new Unit(defaultUnitBuild);
            playerData.teamInBench.Collection.Add(unit);
            playerUnitCreated.Raise(unit);
            newPlayerUnitBuildInInventory.Raise(unit);

            return unit;
        }
    }
}