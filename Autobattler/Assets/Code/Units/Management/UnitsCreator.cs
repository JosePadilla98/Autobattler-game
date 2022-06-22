using Autobattler.Events;
using Autobattler.ExpModule;
using Autobattler.Grid;
using Autobattler.RunData;
using Autobattler.ScriptableCollections;
using UnityEngine;

namespace Autobattler.Units.Management
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
        private UnitsLevellingModel levelBonifications;

        public Unit CreateUnitInGrid(UnitBuild blueprint, Side side)
        {
            Unit unit;

            if (side == Side.LEFT)
            {
                unit = new PlayerUnit(blueprint, levelBonifications);
                playerData.teamInGrid.Collection.Add(unit);
                playerData.team.Collection.Add(unit);
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
            var unit = new PlayerUnit(defaultUnitBuild, levelBonifications);
            playerData.teamInBench.Collection.Add(unit);
            playerData.team.Collection.Add(unit);
            playerUnitCreated.Raise(unit);
            newPlayerUnitBuildInInventory.Raise(unit);

            return unit;
        }
    }
}