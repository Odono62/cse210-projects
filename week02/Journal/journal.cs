using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine($"\nTotal Entries: {_entries.Count}\n");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}"
                );
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                Entry entry = new Entry();

                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                entry._mood = parts[3];

                _entries.Add(entry);
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void SearchEntries(string keyword)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (
                entry._entryText.ToLower().Contains(keyword.ToLower()) ||
                entry._promptText.ToLower().Contains(keyword.ToLower()) ||
                entry._mood.ToLower().Contains(keyword.ToLower())
            )
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching entries found.");
        }
    }
}