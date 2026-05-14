using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished:");

        int usernumber = -1;
        while (usernumber != 0)
        {
            Console.Write("Enter a number:");
            usernumber = int.Parse(Console.ReadLine());


            if (usernumber != 0)
            {
                numbers.Add(usernumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)        {
            sum += number;
        }

        double average = (double)sum / numbers.Count;   

        int largest = numbers[0];
        foreach (int number in numbers)        {
            if (number > largest)
            {
                largest = number;
            }
        }

        int smallestpositive = numbers[0];
        foreach (int number in numbers)        {
            if (number > 0 && number < smallestpositive) 
            {
                smallestpositive = number;
            }
        }

        numbers.Sort();

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Largest: {largest}");

        if (smallestpositive != int.MaxValue)
        {
            Console.WriteLine($"Smallest positive number is: {smallestpositive}");
        }

        Console.WriteLine("Sorted list of numbers:");
        foreach (int number in numbers)        {
            Console.WriteLine(number);
        }
    }
}