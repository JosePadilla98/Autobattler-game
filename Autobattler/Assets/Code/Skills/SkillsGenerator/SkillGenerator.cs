using System;
using System.Collections.Generic;
using System.Linq;
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
            private List<Type> availableEndNodes;

            public NodesList()
            {
                availableNodes = SkillsNodesPool.GetSkillsNodesList();
                availableEndNodes = SkillsNodesPool.GetSkillsLastNodesList();
            }

            public ISkillNode GetNewNode(bool onlyLastNode)
            {
                List<Type> listToUse = onlyLastNode
                    ? availableEndNodes
                    : availableEndNodes.Concat(availableNodes).ToList();

                int index = RandomController.Random.Next(listToUse.Count);
                Type typeToCreate = listToUse[index];
                ISkillNode node = Activator.CreateInstance(typeToCreate) as ISkillNode;
                RemoveNode(typeToCreate, onlyLastNode);

                return node;
            }

            private void RemoveNode(Type type, bool isEndNode)
            {
                if (isEndNode)
                {
                    availableEndNodes.Remove(type);
                    if (availableEndNodes.Count == 0)
                        SkillsNodesPool.RepopulateEndNodesList(availableEndNodes);
                }
                {
                    availableNodes.Remove(type);
                    if (availableNodes.Count == 0)
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
            float powerValue = 10;
            float complexity = CalculateComplexity(powerValue);
            ChainPayload payload = new ChainPayload(powerValue: powerValue, complexity: complexity);

            AddNewNodeToThisRoot(rootNodes, payload);

            return new Skill(rootNodes.ToArray());
        }

        public void AddNewNodeToThisRoot(List<ISkillNode> root, ChainPayload payload)
        {
            ISkillNode newRootChild = GetNewRandomNode(payload);
            root.Add(newRootChild);

            newRootChild.ContinueChain(
                startNewRootNodeDelegate: (ChainPayload newPayload) =>
                    AddNewNodeToThisRoot(root, newPayload),
                payload
            );
        }

        public void FillThisNode(
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ref ISkillNode node,
            ChainPayload payload
        )
        {
            node = GetNewRandomNode(payload);
            node.ContinueChain(startNewRootNodeDelegate, payload);
        }

        public ISkillNode GetNewRandomNode(ChainPayload payload)
        {
            ISkillNode output = null;
            while (output == null)
            {
                ISkillNode newNode = availableNodes.GetNewNode(
                    onlyLastNode: payload.complexity <= 1f
                );

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
            for (int i = 0; i < roots.Count(); i++)
            {
                ISkillNode rootNode = roots[i];
                sb.AppendLine($@"{Environment.NewLine}{i + 1}. {rootNode.Text()}");
            }

            return sb.ToString();
        }
    }
}