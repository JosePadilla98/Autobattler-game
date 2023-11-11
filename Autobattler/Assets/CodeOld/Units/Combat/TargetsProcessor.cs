using System;
using System.Collections.Generic;
using AutobattlerOld.Grid;
using AutobattlerOld.Grid.Generic;
using UnityEngine;

namespace AutobattlerOld.Units.Combat
{
    public enum TargetTypes
    {
        CLOSEST_ENEMY
    }

    public static class TargetsProcessor
    {
        private static readonly List<Fighter> objetivesBuffer = new(12);
        private static GridsController<Fighter> Battlefield => App.Battlefield;

        public static List<Fighter> GetObjetives(TargetTypes type, Position ownPos)
        {
            objetivesBuffer.Clear();

            switch (type)
            {
                case TargetTypes.CLOSEST_ENEMY:

                    // Grid<Fighter> gridObjective =
                    //     (ownPos.side == Side.LEFT) ? Battlefield.rightGrid : Battlefield.leftGrid;

                    var creature = GetClosestEnemy(ownPos);
                    objetivesBuffer.Add(creature);
                    break;
            }

            return objetivesBuffer;
        }

        public static Fighter GetClosestEnemy(Position referencePosition)
        {
            Grid<Fighter> oppositeGrid = Battlefield.GetOppositeGrid(referencePosition.side);

            int[] order = null;
            switch (referencePosition.heigh)
            {
                case Height.UP:
                    order = new[] { (int)Height.UP, (int)Height.CENTER, (int)Height.DOWN };
                    break;

                case Height.CENTER:
                    order = new[] { (int)Height.CENTER, (int)Height.UP, (int)Height.DOWN };
                    break;

                case Height.DOWN:
                    order = new[] { (int)Height.DOWN, (int)Height.CENTER, (int)Height.UP };
                    break;

                default:
                    throw new Exception("Incorrect height");
            }

            Fighter fighter =
                SearchUntilGetOne(order, oppositeGrid.front)
                ?? SearchUntilGetOne(order, oppositeGrid.back);

            if (fighter == null)
            {
                throw new Exception(
                    "You are looking for a unit but there isn't any. What the hell is happening? "
                );
            }

            return fighter;
        }

        public static Fighter SearchUntilGetOne(int[] order, IGridSlot<Fighter>[] column)
        {
            foreach (int i in order)
            {
                var combatInstance = column[i].GetItem();
                if (combatInstance != null)
                    return combatInstance;
            }

            return null;
        }
    }
}
