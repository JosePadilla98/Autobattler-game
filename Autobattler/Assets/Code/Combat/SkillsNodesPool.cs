using System;
using System.Collections.Generic;

namespace Autobattler
{
    public static class SkillsNodesPool
    {
        private static readonly Type[] NODES_POOL = { typeof(RowMovement) };

        private static readonly Type[] LAST_NODES_POOL = { typeof(AttackClosestAndMoveIt), };

        public static List<Type> GetSkillsNodesList()
        {
            return new List<Type>(NODES_POOL);
        }

        public static List<Type> GetSkillsLastNodesList()
        {
            return new List<Type>(LAST_NODES_POOL);
        }

        public static void RepopulateNodesList(List<Type> list)
        {
            list.AddRange(NODES_POOL);
        }

        public static void RepopulateLastNodesList(List<Type> list)
        {
            list.AddRange(LAST_NODES_POOL);
        }
    }
}