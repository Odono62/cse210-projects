public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    // Constructor used when loading saved state
    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus,
        int timesCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        if (_timesCompleted < _target)
        {
            _timesCompleted++;

            int earned = GetPoints();

            if (_timesCompleted == _target)
            {
                earned += _bonus;
            }

            return earned;
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _target;
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete() ? "X" : " ")}] Completed {_timesCompleted}/{_target}";
    }

    public override string SaveData()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_timesCompleted}";
    }
}