using System;
using System.Collections.Generic;
using Autobattler.Grid;
using Autobattler.Grid.Generic;

namespace Autobattler.Units.Combat
{
    public enum TargetTypes
    {
        CLOSEST_ENEMY
    }

    public static class TargetsProcessor
    {
        private static readonly List<Fighter> objetivesBuffer = new(12);
        private static GridsController<Fighter> Battlefield => null;

        public static List<Fighter> GetObjetives(TargetTypes type, Position ownPos)
        {
            objetivesBuffer.Clear();

            switch (type)
            {
                case TargetTypes.CLOSEST_ENEMY:

                    Grid<Fighter> gridObjetive;
                    if (ownPos.side == Side.LEFT)
                        gridObjetive = Battlefield.rightGrid;
                    else
                        gridObjetive = Battlefield.leftGrid;

                    var creature = GetClosestEnemy(ownPos);
                    objetivesBuffer.Add(creature);
                    break;
            }

            return objetivesBuffer;
        }

        public static Fighter GetClosestEnemy(Position referencePosition)
        {
            var oppositeGrid = Battlefield.GetOppositeGrid(referencePosition.side);

            //InitialValues the closest heigh
            int[] order = null;
            switch (referencePosition.heigh)
            {
                case 1:
                    order = new[] { 1, 2, 3 };
                    break;

                case 2:
                    order = new[] { 2, 1, 3 };
                    break;

                case 3:
                    order = new[] { 3, 2, 1 };
                    break;
            }

            var unit = SearchUntilGetOne(order, oppositeGrid.front);
            if (unit == null)
                unit = SearchUntilGetOne(order, oppositeGrid.back);

            return null;
        }

        public static Fighter SearchUntilGetOne(int[] order, IGridSlot<Fighter>[] column)
        {
            foreach (var i in order)
            {
                var combatInstance = column[i].GetItem();
                if (combatInstance != null) return combatInstance;
            }

            throw new Exception("You are looking for a unit but there isn't any. What the hell is happening?");
        }
    }
}