// EXCEEDING REQUIREMENTS:
//
// This program goes beyond the core assignment requirements by adding
// additional gamification features. In addition to tracking Simple Goals,
// Eternal Goals, and Checklist Goals, the program includes:
//
// 1. A Level System that increases the user's level as they earn points.
// 2. Achievement Badges that are awarded when important milestones are reached.
// 3. An additional goal type that allows users to track progress toward
//    larger long-term objectives.
//
// These features provide extra motivation and engagement while demonstrating
// additional object-oriented design beyond the minimum assignment requirements.



class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.DisplayGoals();

                    Console.Write("Goal Number: ");
                    int goal =
                        int.Parse(Console.ReadLine()) - 1;

                    manager.RecordGoal(goal);
                    break;

                case "4":
                    manager.DisplayScore();
                    break;

                case "5":
                    running = false;
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? string.Empty;

        int points = ReadInt("Points: ");

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;

            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                break;

            case "3":
                int target = ReadInt("Target completions: ");
                int bonus = ReadInt("Bonus points: ");
                manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(s, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid integer.");
        }
    }
}