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
        Console.WriteLine("Select goal type: 1) Simple 2) Eternal 3) Checklist");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (type == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (type == "3")
        {
            Console.Write("Target completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (goal != null)
        {
            manager.AddGoal(goal);
            Console.WriteLine("Goal added.");
        }
    }
}