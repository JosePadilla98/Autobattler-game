using System;
using System.Collections.Generic;

namespace Auttobattler.Backend
{
    public enum TargetTypes
    {
        CLOSEST_ENEMY
    }

    public static class TargetsProcessor
    {
        private static List<Fighter> objetivesBuffer = new List<Fighter>(12);
        private static GridsController<Fighter> Battlefield { get => InstancesProvider.GetBattlefield(); }

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

                    Fighter creature = GetClosestEnemy(ownPos);
                    objetivesBuffer.Add(creature);
                    break;
            }

            return objetivesBuffer;
        }

        public static Fighter GetClosestEnemy(Position referencePosition)
        {
            Grid<Fighter> oppositeGrid = Battlefield.GetOppositeGrid(referencePosition.side);

            //Get the closest heigh
            int[] order = null;
            switch (referencePosition.heigh)
            {
                case 1:
                    order = new int[] { 1, 2, 3 };
                    break;

                case 2:
                    order = new int[] { 2, 1, 3 };
                    break;

                case 3:
                    order = new int[] { 3, 2, 1 };
                    break;
            }

            Fighter unit = SearchUntilGetOne(order, oppositeGrid.front);
            if (unit == null)
                unit = SearchUntilGetOne(order, oppositeGrid.back);

            return unit;
        }

        public static Fighter SearchUntilGetOne(int[] order, IGridSlot<Fighter>[] column)
        {
            foreach (int i in order)
            {
                Fighter combatInstance = column[i].GetItem();
                if (combatInstance != null) return combatInstance;
            }

            throw new Exception("You are looking for a unit but there isn't any. What the hell is happening?");
        }
    }

}
