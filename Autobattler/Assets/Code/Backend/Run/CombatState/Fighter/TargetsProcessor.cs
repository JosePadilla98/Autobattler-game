using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Backend.Run.CombatState
{
    public enum TargetTypes
    {
        CLOSEST_ENEMY
    }

    public static class TargetsProcessor
    {
        private static List<Fighter> objetives = new List<Fighter>(12);
        private static CombatGrid LeftGrid { get => Battlefield.Instance.leftGrid; }
        private static CombatGrid RightGrid { get => Battlefield.Instance.rightGrid; }

        public static List<Fighter> GetObjetives(TargetTypes type, Position ownPos)
        {
            objetives.Clear();

            switch (type)
            {
                case TargetTypes.CLOSEST_ENEMY:

                    CombatGrid gridObjetive;
                    if (ownPos.side == Side.LEFT)
                        gridObjetive = RightGrid;
                    else
                        gridObjetive = LeftGrid;

                    Fighter creature = GetClosestEnemy(ownPos);
                    objetives.Add(creature);
                    break;
            }

            return objetives;
        }

        public static Fighter GetClosestEnemy(Position referencePosition)
        {
            CombatGrid oppositeGrid = Battlefield.Instance.GetOppositeGrid(referencePosition.side);

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

        public static Fighter SearchUntilGetOne(int[] order, CombatSlot[] column)
        {
            foreach (int i in order)
            {
                Fighter combatInstance = column[i].Unit;
                if (combatInstance != null) return combatInstance;
            }

            throw new Exception("You are looking for a unit but there isn't any. What the hell is happening?");
        }
    }

}
