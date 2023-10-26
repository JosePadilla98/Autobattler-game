public class RowMovement : ISkillNode
{
    private float _value;

    public RowMovement(float value)
    {
        _value = value;
    }

    public SkillNodeRequirements Requirements()
    {
        return new SkillNodeRequirements(10);
    }

    public string Text()
    {
        return @"<i>From back row=></i> 
        1.Move forward
        2.";
    }
}
