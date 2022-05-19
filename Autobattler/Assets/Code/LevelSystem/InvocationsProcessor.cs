using System;
using Autobattler.GameControllers;
using Autobattler.Grid;
using Autobattler.Grid.ManagementState;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.LevelSystem
{
    [Serializable]
    internal class InvocationsProcessor
    {
        [SerializeField]
        private Battlefield_U battlefield_U;
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private UnitsCollection enemies;

        public void SummonUnits(InvocationsData data, Side side)
        {
            IterateColumnAndSummon(data.frontColumn, side, Column.FRONT);
            IterateColumnAndSummon(data.backColumn, side, Column.BACK);
        }

        private void IterateColumnAndSummon(UnitBuild[] builds, Side side, Column column)
        {
            for (var i = 0; i < builds.Length; i++)
            {
                var build = builds[i];
                if (build == null) continue;

                var unit = new _Unit(build);
                var position = new Position(i, column, side);

                battlefield_U.AttachItem(unit, position);

                if(side == Side.LEFT)
                    playerData.teamInGrid.Collection.Add(unit);
                else
                    enemies.Collection.Add(unit);
            }
        }
    }
}