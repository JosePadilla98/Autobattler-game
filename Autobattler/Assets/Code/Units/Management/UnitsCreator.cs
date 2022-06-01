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
        private PlayerData playerData;
        [SerializeField]
        private UnitsCollection enemies;

        public Unit CreateUnit(UnitBuild blueprint, Side side, bool inGrid = true)
        {
            var unit = new Unit(blueprint);

            if (side == Side.LEFT)
            {
                if(inGrid)
                    playerData.teamInGrid.Collection.Add(unit);
                else
                    playerData.teamInBench.Collection.Add(unit); 

                playerUnitCreated.Raise(unit);
            }
            else
            {
                if (!inGrid)
                    throw new Exception("Due to the design of this game, this cannot happen");

                enemies.Collection.Add(unit);
            }

            return unit;
        }
    }
}