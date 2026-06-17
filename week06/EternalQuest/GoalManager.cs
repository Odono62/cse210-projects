using System.IO;
using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()}");
        }
    }

    public void RecordGoal(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        var lines = new List<string>();
        lines.Add($"Score|{_score}");

        foreach (var g in _goals)
        {
            lines.Add(g.SaveData());
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine($"Saved { _goals.Count } goals to {filename}.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        var lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split('|');

            if (parts.Length == 0) continue;

            if (parts[0] == "Score" && parts.Length >= 2)
            {
                int.TryParse(parts[1], out _score);
                continue;
            }

            switch (parts[0])
            {
                case "SimpleGoal":
                    // SimpleGoal|name|description|points|completed
                    if (parts.Length >= 5)
                    {
                        var name = parts[1];
                        var desc = parts[2];
                        int.TryParse(parts[3], out int pts);
                        bool.TryParse(parts[4], out bool completed);
                        _goals.Add(new SimpleGoal(name, desc, pts, completed));
                    }
                    break;

                case "EternalGoal":
                    // EternalGoal|name|description|points
                    if (parts.Length >= 4)
                    {
                        var name = parts[1];
                        var desc = parts[2];
                        int.TryParse(parts[3], out int pts);
                        _goals.Add(new EternalGoal(name, desc, pts));
                    }
                    break;

                case "ChecklistGoal":
                    // ChecklistGoal|name|description|points|target|bonus|timesCompleted
                    if (parts.Length >= 7)
                    {
                        var name = parts[1];
                        var desc = parts[2];
                        int.TryParse(parts[3], out int pts);
                        int.TryParse(parts[4], out int target);
                        int.TryParse(parts[5], out int bonus);
                        int.TryParse(parts[6], out int times);
                        _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus, times));
                    }
                    break;
            }
        }

        Console.WriteLine($"Loaded {_goals.Count} goals. Score set to {_score}.");
    }
}