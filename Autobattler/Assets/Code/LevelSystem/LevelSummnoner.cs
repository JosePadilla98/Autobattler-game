using System;
using Autobattler.Grid;
using Autobattler.Unit.Unit;

namespace Autobattler.LevelSystem
{
    internal class LevelSummnoner
    {
        private readonly LevelsSystem parent;

        public LevelSummnoner(LevelsSystem parent)
        {
            this.parent = parent;
        }

        private GridsController<Unit.Unit.Unit> GridsController => parent.parent.gridsController;

        public void SummonEnemies(InvocationsData data)
        {
            Action<UnitBuild[], Side, Column> iterateColumnAndSummon = (builds, side, column) =>
            {
                for (var i = 0; i < builds.Length; i++)
                {
                    var build = builds[i];
                    if (build == null)
                        continue;

                    var unit = new Unit.Unit.Unit(build);
                    var position = new Position(i, column, side);

                    GridsController.AttachItem(unit, position);
                }
            };

            iterateColumnAndSummon(data.frontColumn, Side.RIGHT, Column.FRONT);
            iterateColumnAndSummon(data.backColumn, Side.RIGHT, Column.BACK);
        }
    }
}