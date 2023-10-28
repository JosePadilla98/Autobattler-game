using System;
using System.Collections.Generic;
using System.Text;

namespace Autobattler
{
    public class RowMovement : ISkillNode
    {
        private float _value;
        private List<ISkillNode> mainChain = new();
        private List<ISkillNode> secondaryChain = new();

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
            return new SkillNodeRequirements(minimunPowerValue: 10f, minimunComplexity: 1f);
        }

        void ISkillNode.ContinueChain(
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        )
        {
            //FROM BACK ROW
            ChainPayload mainChainPayload = payload;
            mainChainPayload.complexity = -1f;
            mainChainPayload.powerValue =
                (mainChainPayload.powerValue * 1.6f) - Movement.NormalizedValue();

            SkillGenerator.current.AddNewNodeToTheseRoots(mainChain, mainChainPayload);

            //FROM FRONT ROW
            ChainPayload secondaryChainPayload = payload;
            secondaryChainPayload.complexity = secondaryChainPayload.complexity / 2f;
            secondaryChainPayload.powerValue = mainChainPayload.powerValue * 0.4f;

            SkillGenerator.current.AddNewNodeToTheseRoots(secondaryChain, secondaryChainPayload);
        }

        void ISkillNode.Initialize(ChainPayload payload) { }
    }
}
