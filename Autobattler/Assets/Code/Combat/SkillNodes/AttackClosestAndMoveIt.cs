namespace Autobattler
{
    public class AttackClosestAndMoveIt : ISkillNode, ILastSkillNode
    {
        private float _value;
        public float AttackPower => _value * 15;
        public float SecondaryAttackPower => _value * 5;

        string ISkillNode.Text()
        {
            return $@"Damage the closest enemy for {AttackPower}% <color=#2d7abd>magic</color>. Push him into the back row. If there is an enemy behind, swap him and damage him for {SecondaryAttackPower}% <color=#2d7abd>magic</color>";
        }

        SkillNodeRequirements ISkillNode.GetRequirements()
        {
            return SkillNodeRequirements.Zero;
        }

        void ISkillNode.ContinueChain(
            GetNewRandomNodeDelegate getNewRandomNodeDelegate,
            StartNewRootNodeDelegate startNewRootNodeDelegate,
            ChainPayload payload
        )
        {
            payload.complexity -= 1;
            //
            if (payload.complexity > 0)
                startNewRootNodeDelegate(payload);
        }

        void ISkillNode.Initialize(ChainPayload payload)
        {
            _value = payload.powerValue - Movement.NormalizedValue();
        }
    }
}
