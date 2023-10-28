using System;
using System.Collections.Generic;

namespace Autobattler
{
    public static class SkillsNodesPool
    {
        private static readonly Type[] NODES_POOL =
        {
            typeof(AttackClosestAndMoveIt),
            typeof(RowMovement)
        };

        public static List<Type> GetSkillsNodesList()
        {
            return new List<Type>(NODES_POOL);
        }

        public static void RepopulateNodesList(List<Type> list)
        {
            list.AddRange(NODES_POOL);
        }
    }
}
