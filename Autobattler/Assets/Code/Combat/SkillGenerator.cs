using System;
using System.Collections.Generic;

namespace Autobattler
{
    public struct ChainPayload
    {
        public float powerValue;
        public float complexity;

        public ChainPayload(float powerValue, float complexity)
        {
            this.powerValue = powerValue;
            this.complexity = complexity;
        }
    }

    public class SkillGenerator
    {
        private class NodesList
        {
            private List<Type> availableNodes;

            public NodesList()
            {
                availableNodes = SkillsNodesPool.GetSkillsNodesList();
            }

            public ISkillNode GetNewNode()
            {
                int index = RandomController.Random.Next(availableNodes.Count);
                Type typeToCreate = availableNodes[index];
                ISkillNode node = Activator.CreateInstance(typeToCreate) as ISkillNode;
                availableNodes.RemoveAt(index);
                RepopulateIfNeeded();

                return node;
            }

            private void RepopulateIfNeeded()
            {
                if (availableNodes.Count == 0)
                {
                    SkillsNodesPool.RepopulateNodesList(availableNodes);
                }
            }
        }

        private NodesList availableNodes;
        private List<ISkillNode> rootNodes = new();

        private float CalculateComplexity(float powerValue) => powerValue / 5;

        public SkillGenerator()
        {
            availableNodes = new NodesList();
        }

        public Skill Build()
        {
            float powerValue = 15;
            float complexity = CalculateComplexity(powerValue);
            ChainPayload payload = new ChainPayload(powerValue: powerValue, complexity: complexity);

            StartNewRootNode(payload);

            return new Skill(rootNodes.ToArray());
        }

        public void StartNewRootNode(ChainPayload payload)
        {
            ISkillNode newRootNode = GetNewRandomNode(payload);
            rootNodes.Add(newRootNode);

            newRootNode.ContinueChain(
                getNewRandomNodeDelegate: GetNewRandomNode,
                startNewRootNodeDelegate: StartNewRootNode,
                payload
            );
        }

        private ISkillNode GetNewRandomNode(ChainPayload payload)
        {
            ISkillNode output = null;
            while (output == null)
            {
                ISkillNode newNode = availableNodes.GetNewNode();
                if (newNode.AreRequirementsMet(payload))
                {
                    output = newNode;
                    output.Initialize(payload);
                }
            }

            return output;
        }
    }

    public class Skill
    {
        public ISkillNode[] chain;

        public Skill(ISkillNode[] chain)
        {
            this.chain = chain;
        }
    }
}
