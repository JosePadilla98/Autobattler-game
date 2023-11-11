namespace Autobattler
{
    public class AttackClosestAndMoveIt : ISkillNode, ISkillEndNode
    {
        private float inputValue;
        private float modifiedInputValue => inputValue - Movement.NormalizedValue();
        private float AttackPower => modifiedInputValue * 15;
        private float SecondaryAttackPower => modifiedInputValue * 5;

        string ISkillNode.Text()
        {
            return $@"Damage the closest enemy for {AttackPower}% <color=#2d7abd>magic</color>. Push him into the back row. If there is an enemy behind, swap him and damage him for {SecondaryAttackPower}% <color=#2d7abd>magic</color>";
        }

        SkillNodeRequirements ISkillNode.GetRequirements()
        {
            return SkillNodeRequirements.Zero;
        }

        void ISkillNode.ContinueChain(
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        ) { }

        void ISkillNode.Initialize(ChainPayload payload)
        {
            inputValue = payload.powerValue;
        }
    }
}