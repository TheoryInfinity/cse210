public abstract class Goal
{
    protected int _pointValue;
    protected string _name;
    protected string _desc;

    public Goal()
    {
        _pointValue = 0;
        _name = "Missing Name";
        _desc = "Missing Description";
    }

    public Goal(int points, string name, string description)
    {
        _pointValue = points;
        _name = name;
        _desc = description;

    }

    public abstract void Display();

    public abstract int IsCompleted();

    public virtual void SetCompleted()
    {

    }

    public string GetName()
    {
        return _name;
    }
    public abstract string GetRep();


}