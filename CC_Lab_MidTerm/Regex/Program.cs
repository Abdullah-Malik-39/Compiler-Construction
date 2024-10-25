using System;
using System.Text.RegularExpressions;

class PasswordGenerator
{
    static void Main()
    {
        Console.WriteLine("Enter Registration Number:");
        string regNo = Console.ReadLine();

        Console.WriteLine("Enter First Name:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter Last Name:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter Favourite Movie:");
        string favouriteMovie = Console.ReadLine();

        string regNoDigits = ExtractDigits(regNo, 2);
        string firstLetter = ExtractLetter(firstName, 1);
        string lastLetter = ExtractLetter(lastName, 1);
        string movieChars = ExtractCharacters(favouriteMovie, 2);


        string specialChars = "!@$%^&*()-_=+<>?";

        string skeleton = regNoDigits + firstLetter + lastLetter + movieChars;

        string password = GeneratePassword(skeleton, specialChars);

        Console.WriteLine("Generated Password: " + password);
    }

    static string ExtractDigits(string input, int count)
    {
        Match match = Regex.Match(input, @"\d+");
        return match.Success && match.Value.Length >= count ? match.Value.Substring(0, count) : "00";
    }

    static string ExtractLetter(string input, int position)
    {
        return input.Length > position ? input[position].ToString() : "X";
    }

    static string ExtractCharacters(string input, int count)
    {
        return input.Length >= count ? input.Substring(0, count) : new string('X', count);
    }

    static string GeneratePassword(string skeleton, string specialChars)
    {
        Random rnd = new Random();
        string password = skeleton;

        for (int i = 0; i < 2; i++)
        {
            password += specialChars[rnd.Next(specialChars.Length)];
        }

        while (password.Length < 14)
        {
            char nextChar = (char)rnd.Next(33, 126);
            if (nextChar != '#' && !char.IsControl(nextChar))
            {
                password += nextChar;
            }
        }
        return ShuffleString(password);
    }

    static string ShuffleString(string input)
    {
        char[] array = input.ToCharArray();
        Random rnd = new Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
        return new string(array);
    }
}
