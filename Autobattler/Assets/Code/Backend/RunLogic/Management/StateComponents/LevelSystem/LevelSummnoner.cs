using Assets.Code.Backend.RunLogic.GenericGrid;
using Assets.Code.Backend.RunLogic.Management.Controllers.LevelSystem;
using System;

namespace Auttobattler.Backend.RunLogic.Management
{
    class LevelSummnoner
    {
        private LevelsSystem parent;
        private GridsController<Unit> GridsController { get => parent.parent.gridsController; }

        public LevelSummnoner(LevelsSystem parent)
        {
            this.parent = parent;
        }

        public void SummonEnemies(InvocationsData data)
        {
            Action<UnitBuild[], Side, Column> iterateColumnAndSummon = (builds, side, column) =>
            {
                for (int i = 0; i < builds.Length; i++)
                {
                    UnitBuild build = builds[i];
                    if (build == null)
                        continue;

                    Unit unit = new Unit(build);
                    Position position = new Position(i, column, side);

                    GridsController.AttachItem(unit, position);
                }
            };

            iterateColumnAndSummon(data.frontColumn, Side.RIGHT, Column.FRONT);
            iterateColumnAndSummon(data.backColumn, Side.RIGHT, Column.BACK);
        }
    }
}
