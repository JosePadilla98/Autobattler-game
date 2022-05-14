using System;
using Autobattler.Grid;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.LevelSystem
{
    [Serializable]
    internal class InvocationsProcessor
    {
        [SerializeField]
        //private Battlefield_U battlefield_U;

        public void SummonEnemies(InvocationsData data)
        {
            IterateColumnAndSummon(data.frontColumn, Side.RIGHT, Column.FRONT);
            IterateColumnAndSummon(data.backColumn, Side.RIGHT, Column.BACK);
        }

        private void IterateColumnAndSummon(UnitBuild[] builds, Side side, Column column)
        {
            for (var i = 0; i < builds.Length; i++)
            {
                var build = builds[i];
                if (build == null) continue;

                var unit = new Unit(build);
                var position = new Position(i, column, side);

                //battlefield_U.AttachItem(unit, position);
            }
        }
    }
}