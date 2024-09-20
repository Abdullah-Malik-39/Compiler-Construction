using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a task to run:");
        Console.WriteLine("1. Detect Logical Operators (&&, ||, !)");
        Console.WriteLine("2. Detect Relational Operators (==, !=, >, <, >=, <=)");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Task1();
        }
        else if (choice == "2")
        {
            Task2();  
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }

    static void Task1()
    {
        Console.WriteLine("Enter a string containing logical operators (&&, ||, !):");
        string input = Console.ReadLine();
        string pattern = @"(&&)|(\|\|)|(!)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine("Found logical operator: " + match.Value);
            }
        }
        else
        {
            Console.WriteLine("No logical operators found in the input.");
        }
    }
    static void Task2()
    {
        Console.WriteLine("Enter a string containing relational operators (==, !=, >, <, >=, <=):");
        string input = Console.ReadLine();
        string pattern = @"(==)|(!=)|(>=)|(<=)|>|<";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine("Found relational operator: " + match.Value);
            }
        }
        else
        {
            Console.WriteLine("No relational operators found in the input.");
        }
    }
}
