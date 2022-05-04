using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public enum TargetTypes
    {
        ENEMY_CLOSEST
    }

    public static class TargetsProcessor
    {
        static List<UnitCombatInstance> objetives = new List<UnitCombatInstance>(12);

        public static List<UnitCombatInstance> GetObjetives(TargetTypes type, Position ownPos, Battlefield battleField)
        {
            objetives.Clear();

            switch (type)
            {
                case TargetTypes.ENEMY_CLOSEST:

                    Grid gridObjetive;
                    if (ownPos.side == Side.LEFT)
                        gridObjetive = battleField.rightGrid;
                    else
                        gridObjetive = battleField.leftGrid;

                    UnitCombatInstance creature = GetClosest(ownPos, gridObjetive);
                    objetives.Add(creature);
                    break;
            }

            return objetives;
        }

        public static UnitCombatInstance GetClosest(Position pos, Grid grid)
        {
            int[] order = null;

            switch (pos.heigh)
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

            UnitCombatInstance unit = SearchUntilGetOne(order, grid.front);
            if (unit == null)
                unit = SearchUntilGetOne(order, grid.back);

            return unit;
        }

        public static UnitCombatInstance SearchUntilGetOne(int[] order, CombatSlot[] column)
        {
            foreach (int i in order)
            {
                UnitCombatInstance c = column[i].unit;
                if (c != null) return c;
            }

            return null;
        }
    }

}
