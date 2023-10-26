public class AttackClosestAndMoveIt : ISkillNode
{
    private float _value;
    public float AttackPower => _value * 15;
    public float SecondaryAttackPower => _value * 5;

    public AttackClosestAndMoveIt(float value)
    {
        _value = value - Movement.NormalizedValue();
    }

    public SkillNodeRequirements Requirements()
    {
        return SkillNodeRequirements.Zero;
    }

    public string Text()
    {
        return $@"Damage the closest enemy for {AttackPower}% <color=#2d7abd>magic</color>. Push him into the back row. If there is an enemy behind, swap him and damage him for {SecondaryAttackPower}% <color=#2d7abd>magic</color>";
    }
}
