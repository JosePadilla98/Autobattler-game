using UnityEngine;

namespace Autobattler
{
    public delegate void StartNewRootNodeDelegate(ChainPayload payload);

    public interface ISkillEndNode { }

    public interface ISkillNode
    {
        public string Text();

        protected SkillNodeRequirements GetRequirements();

        public bool AreRequirementsMet(ChainPayload payload)
        {
            Debug.Log($@"Checking requirements of {this.GetType().Name}");
            SkillNodeRequirements requirements = GetRequirements();

            if (payload.powerValue < requirements.minimunPowerValue)
                return false;

            return true;
        }

        public void ContinueChain(
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        );

        public void Initialize(ChainPayload payload);
    }

    public struct SkillNodeRequirements
    {
        public float minimunPowerValue;
        public float minimunComplexity;

        public SkillNodeRequirements(float minimunPowerValue, float minimunComplexity)
        {
            this.minimunPowerValue = minimunPowerValue;
            this.minimunComplexity = minimunComplexity;
        }

        public static SkillNodeRequirements Zero = new(1f, 1f);
    }
}
