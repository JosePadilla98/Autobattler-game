
using Auttobattler.Backend.Run.CombatState;
using System;

namespace Auttobattler.Backend.Run.ManagementState
{
    public class ManagementStateManager
    {
        private PlayerControllerFrontend playerController;
        private Grid playerGrid;
        private PlayerData playerData;
    }

    public class PreCombatSummoner
    {
        public static void SummonEnemyUnits(InvocationsData data)
        {
            Action<UnitBuild[], Side, Column> iterateColumnAndSummon = (blueprintsInColumn, side, column) =>
            {
                for (int i = 0; i < blueprintsInColumn.Length; i++)
                {
                    UnitBuild blueprint = blueprintsInColumn[i];
                    if (blueprint == null)
                        continue;

                    Fighter combatInstance = new Unit(blueprint).BuildCombatInstance();
                    Position location = new Position(i, column, side);
                    Battlefield.Instance.SummonUnit(combatInstance, location);
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
