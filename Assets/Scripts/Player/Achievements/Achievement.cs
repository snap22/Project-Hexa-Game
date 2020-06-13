

public abstract class Achievement
{


    private bool completed;
    private AchievType type;
    private int requiredAmount;

    public string name { get; private set; }

    public Achievement(string name, int requiredAmount, AchievType type)
    {
        this.name = name;
        this.completed = false;
        this.type = type;
        this.requiredAmount = requiredAmount;
    }

    protected void Complete()
    {
        this.completed = true;
        throw new AchievementCompletedException();
    }

    protected int Required
    {
        get { return this.requiredAmount; }
    }

    public AchievType GetAchievType()
    {
        return this.type;
    }

    public bool IsCompleted() => this.completed;

    
    public abstract string GetDescription();

    public abstract void Check(Building building);
    public abstract void Check(Player player);

    
}
