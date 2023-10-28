using System.Collections.Generic;

namespace Autobattler
{
    public delegate ISkillNode GetNewRandomNodeDelegate(ChainPayload payload);
    public delegate void StartNewRootNodeDelegate(ChainPayload payload);

    public interface ILastSkillNode { }

    public interface ISkillNode
    {
        public string Text();

        protected SkillNodeRequirements GetRequirements();

        public bool AreRequirementsMet(ChainPayload payload)
        {
            SkillNodeRequirements requirements = GetRequirements();

            if (payload.powerValue < requirements.minimunPowerValue)
                return false;

            return true;
        }

        public void ContinueChain(
            GetNewRandomNodeDelegate getNewRandomNodeDelegate,
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        );

        public void Initialize(ChainPayload payload);
    }

    public struct SkillNodeRequirements
    {
        public float minimunPowerValue;

        public SkillNodeRequirements(float minimunPowerValue)
        {
            this.minimunPowerValue = minimunPowerValue;
        }

        public static SkillNodeRequirements Zero = new(1);
    }
}
