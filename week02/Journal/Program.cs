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
    Console.WriteLine("Welcome to the journal program");
    Console.WriteLine("Please select one of the following choices");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Load");
    Console.WriteLine("4. Save");
    Console.WriteLine("5. Quit");

    Console.Write("Select a choice: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine(prompt);
        Console.Write("> ");

        string response = Console.ReadLine();

        Entry entry = new Entry();

        entry._date = DateTime.Now.ToShortDateString();
        entry._promptText = prompt;
        entry._entryText = response;

        Console.Write("Mood today: ");
        entry._mood = Console.ReadLine();

        journal.AddEntry(entry);
    }

    else if (choice == "2")
    {
        journal.DisplayAll();
    }

    else if (choice == "3")
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        journal.LoadFromFile(file);
    }

    else if (choice == "4")
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        journal.SaveToFile(file);
    }

    else if (choice == "5")
    {
        running = false;
    }
}
    }
}