using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class LevelUnitsLoader : MonoBehaviour
    {
        [SerializeField]
        private int levelCount;

        [SerializeField]
        private Level[] levels;

        private void Start()
        {
            LoadLevel(levels[levelCount]);
        }

        private void LoadLevel(Level level)
        {
            foreach (var summonsPerSide in level.sidesInfo)
            {
                UnitsSummoner.SummonUnitsInGrid(summonsPerSide);
            }
        }
    }
    
    public class HarcodedLevel
    {

    }

    public class UnitsSummoner
    {
        public static void SummonUnitsInGrid(SummonsPerSide level)
        {
            Battlefield battlefield = Battlefield.Instance;
            System.Action<BuildedUnitBlueprint[], Side, Column > iterateColumnAndSummon = (columArray, side, column) =>
            {
                for (int i = 0; i < columArray.Length; i++)
                {
                    BuildedUnitBlueprint blueprint = columArray[i];
                    if (blueprint == null)
                        continue;

                    var buildedUnit = new BuildedUnit(blueprint);
                    var unitCombatInstance = new UnitCombatInstance(buildedUnit, side);

                    Position location = new Position(i, column, side);
                    battlefield.SummonUnit(unitCombatInstance, location);
                }
            };

            Grid grid = battlefield.GetGrid(level.side);
            iterateColumnAndSummon(level.frontColumn, level.side ,Column.FRONT);
            iterateColumnAndSummon(level.backColumn, level. side ,Column.BACK);
        }
    }

}

