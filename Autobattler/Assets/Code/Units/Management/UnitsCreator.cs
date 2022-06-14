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

        [SerializeField]
        private LevelsBonificationsModel levelBonificationsModel;

        public Unit CreateUnitInGrid(UnitBuild blueprint, Side side)
        {
            Unit unit;

            if (side == Side.LEFT)
            {
                unit = new PlayerUnit(blueprint, levelBonificationsModel);
                playerData.teamInGrid.Collection.Add(unit);
                playerUnitCreated.Raise(unit);
            }
            else
            {
                unit = new Unit(blueprint);
                enemies.Collection.Add(unit);
            }

            return unit;
        }

        public Unit CreateNewPlayerUnit()
        {
            var unit = new PlayerUnit(defaultUnitBuild, levelBonificationsModel);
            playerData.teamInBench.Collection.Add(unit);
            playerUnitCreated.Raise(unit);
            newPlayerUnitBuildInInventory.Raise(unit);

            return unit;
        }
    }
}