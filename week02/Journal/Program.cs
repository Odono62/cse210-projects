using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");

                string response = Console.ReadLine();

                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                Console.Write("How are you feeling today? ");
                entry._mood = Console.ReadLine();

                journal.AddEntry(entry);

                Console.WriteLine("\nEntry added successfully.");

                // Motivation quote feature
                Console.WriteLine("Keep going. Small progress matters.");
            }

            else if (choice == "2")
            {
                journal.DisplayAll();
            }

            else if (choice == "3")
            {
                Console.Write("Enter filename to load: ");

                string file = Console.ReadLine();

                journal.LoadFromFile(file);
            }

            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");

                string file = Console.ReadLine();

                journal.SaveToFile(file);
            }

            else if (choice == "5")
            {
                Console.Write("Enter keyword to search: ");

                string keyword = Console.ReadLine();

                journal.SearchEntries(keyword);
            }

            else if (choice == "6")
            {
                running = false;

                Console.WriteLine("Goodbye!");
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}