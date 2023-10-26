public interface ISkillNode
{
    public string Text();

    public SkillNodeRequirements Requirements();
}

public struct SkillNodeRequirements
{
    public float minimunCost;

    public SkillNodeRequirements(float minimunCost)
    {
        this.minimunCost = minimunCost;
    }

    public static SkillNodeRequirements Zero = new(1);
}