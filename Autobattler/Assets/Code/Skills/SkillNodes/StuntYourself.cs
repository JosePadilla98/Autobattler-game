using System;
using Unity.Mathematics;
using UnityEngine;

namespace Autobattler
{
    public class StuntYourself : ISkillNode
    {
        private float value;

        private ISkillNode nextNode;

        void ISkillNode.ContinueChain(
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        )
        {
            ChainPayload newPayload = payload;
            newPayload.powerValue += value;
            SkillGenerator.current.FillThisNode(startNewRootNodeDelegate, ref nextNode, newPayload);
        }

        SkillNodeRequirements ISkillNode.GetRequirements()
        {
            return SkillNodeRequirements.Zero;
        }

        void ISkillNode.Initialize(ChainPayload payload)
        {
            value = Debuff.GetRandomValue();
        }

        string ISkillNode.Text()
        {
            return $@"Stun yourself for <b>{Stun.GetDuration(value)}</b> seconds.{nextNode.Text()}";
        }
    }
}
