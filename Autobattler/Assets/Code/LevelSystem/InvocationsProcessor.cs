using System;
using Autobattler.GameControllers;
using Autobattler.Grid;
using Autobattler.Grid.Logic;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.LevelSystem
{
    [Serializable]
    internal class InvocationsProcessor
    {
        [SerializeField]
        private Battlefield_U battlefield_U;

        [SerializeField]
        private UnitsCreator unitsCreator;

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

                var unit = unitsCreator.CreateUnit(build, side, true);
                var position = new Position(i, column, side);

                battlefield_U.BuildNewItem(unit, position);
            }
        }
    }
}