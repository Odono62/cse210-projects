public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return GetPoints();
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override string GetStatus()
    {
        return _completed ? "[X]" : "[ ]";
    }

    public override string SaveData()
    {
        return $"SimpleGoal,{GetName()},{_completed}";
    }
}
