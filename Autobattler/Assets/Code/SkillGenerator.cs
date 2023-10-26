using System;
using System.Collections.Generic;
using AutobattlerOld;

namespace Autobattler2
{
    public class SkillGenerator
    {
        private float cost = 15;
        const float COST_PER_COMPLEXITY = 5;

        private List<Type> nodes = new List<Type>
        {
            typeof(AttackClosestAndMoveIt),
            typeof(RowMovement),
        };

        // public Skill Build()
        // {
        //     float complexity = cost / COST_PER_COMPLEXITY;

        //     List<ISkillNode> chain = new List<ISkillNode>();
        //     int randomIndex = RandomController.Random.Next(nodes.Count);
        // }
    }

    public class Skill
    {
        public ISkillNode[][] chain;
    }
}
