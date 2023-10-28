using System;
using System.Collections.Generic;
using System.Text;

namespace Autobattler
{
    public class RowMovement : ISkillNode
    {
        private float _value;
        private List<ISkillNode> mainChain;
        private List<ISkillNode> secondaryChain;

        string ISkillNode.Text()
        {
            StringBuilder sb = new("<i>From back row</i> => Move forwards");
            foreach (ISkillNode rootNode in mainChain)
            {
                sb.AppendLine($@"* {rootNode.Text()}");
            }

            sb.AppendLine("\n<i>From front row</i> => Move backwards");
            foreach (ISkillNode rootNode in secondaryChain)
            {
                sb.AppendLine($@"* {rootNode.Text()}");
            }

            return sb.ToString();
        }

        SkillNodeRequirements ISkillNode.GetRequirements()
        {
            return new SkillNodeRequirements(10);
        }

        void ISkillNode.ContinueChain(
            GetNewRandomNodeDelegate getNewRandomNodeDelegate,
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        )
        {
            void StartNewRootNodeInMainChain(ChainPayload payload)
            {
                ISkillNode newRootNode = getNewRandomNodeDelegate(payload)
                mainChain.Add(newRootNode);
                newRootNode.ContinueChain(
                    getNewRandomNodeDelegate: GetNewRandomNode,
                    startNewRootNodeDelegate: StartNewRootNode,
                    payload
                );
            }

            //FROM BACK ROW
            ChainPayload mainChainPayload = payload;
            mainChainPayload.powerValue =
                (mainChainPayload.powerValue * 1.6f) - Movement.NormalizedValue();

            StartNewRootNodeInMainChain(mainChainPayload);

            //FROM FRONT ROW

            //Cambiar startNewRootNodeDelegate en ambas
            throw new NotImplementedException();
        }

        void ISkillNode.Initialize(ChainPayload payload) { }
    }
}
