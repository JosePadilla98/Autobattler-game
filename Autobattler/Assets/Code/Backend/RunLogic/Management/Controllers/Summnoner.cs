using Assets.Code.Backend.RunLogic.Management.Controllers.LevelSystem;
using System;

namespace Auttobattler.Backend.RunLogic.Management
{
    class Summnoner
    {
        private ManagementState parent;

        public Summnoner(ManagementState parent)
        {
            this.parent = parent;
        }

        public void SummonEnemies(InvocationsData data)
        {
            Action<UnitBuild[], Side, Column> iterateColumnAndSummon = (blueprintsInColumn, side, column) =>
            {
                for (int i = 0; i < blueprintsInColumn.Length; i++)
                {
                    UnitBuild blueprint = blueprintsInColumn[i];
                    if (blueprint == null)
                        continue;

                    Unit unit = new Unit(blueprint);
                    Position location = new Position(i, column, side);
                    

                    CombatBattlefield.Instance.SummonUnit(combatInstance, location);
                }
            };

            iterateColumnAndSummon(data.frontColumn, Side.RIGHT, Column.FRONT);
            iterateColumnAndSummon(data.backColumn, Side.RIGHT, Column.BACK);
        }

        public static void SummonPlayerUnits()
        {

        }
    }
}
