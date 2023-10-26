using System;
using AutobattlerOld.GameControllers;
using AutobattlerOld.Grid;
using AutobattlerOld.Grid.Logic;
using AutobattlerOld.ScriptableCollections;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.LevelSystem
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

                var unit = unitsCreator.CreateUnitInGrid(build, side);
                var position = new Position(i, column, side);

                battlefield_U.BuildNewItem(unit, position);
            }
        }
    }
}