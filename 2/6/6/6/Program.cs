using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string str = Console.ReadLine().ToLower();

        string vowels = "аеёиоуыэюя";
        int vowelCount = 0;
        int consonantCount = 0;

        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                if (vowels.Contains(c))
                    vowelCount++;
                else
                    consonantCount++;
            }
        }

        Console.WriteLine($"\nГласных: {vowelCount}");
        Console.WriteLine($"Согласных: {consonantCount}");

        
        Console.ReadLine();
    }
}