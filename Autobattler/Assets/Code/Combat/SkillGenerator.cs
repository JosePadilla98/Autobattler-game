using System;
using System.Collections.Generic;
using System.Text;

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

        #region SINGLETON
        public static SkillGenerator current;

        public SkillGenerator()
        {
            if (current != null)
            {
                throw new Exception("This should never happen");
            }

            Initialize();
            current = this;
        }
        #endregion

        #region PUBLIC

        public Skill Build()
        {
            float powerValue = 15;
            float complexity = CalculateComplexity(powerValue);
            ChainPayload payload = new ChainPayload(powerValue: powerValue, complexity: complexity);

            AddNewNodeToTheseRoots(rootNodes, payload);

            return new Skill(rootNodes.ToArray());
        }

        public void AddNewNodeToTheseRoots(List<ISkillNode> roots, ChainPayload payload)
        {
            ISkillNode newRootNode = GetNewRandomNode(payload);
            roots.Add(newRootNode);

            newRootNode.ContinueChain(
                startNewRootNodeDelegate: (ChainPayload newPayload) =>
                    AddNewNodeToTheseRoots(roots, newPayload),
                payload
            );
        }

        public ISkillNode GetNewRandomNode(ChainPayload payload)
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

        public void Clean()
        {
            Initialize();
        }

        #endregion

        #region PRIVATE
        private void Initialize()
        {
            availableNodes = new NodesList();
        }

        #endregion
    }

    public class Skill
    {
        public ISkillNode[] roots;

        public Skill(ISkillNode[] chain)
        {
            this.roots = chain;
        }

        public string Text()
        {
            StringBuilder sb = new();
            foreach (ISkillNode rootNode in roots)
            {
                sb.AppendLine($@"* {rootNode.Text()}");
            }

            return sb.ToString();
        }
    }
}
