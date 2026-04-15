using System;

static class StringExtensions
{
    public static int CountVowels(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return 0;

        string vowels = "aeiouyаеёиоуыэюя";
        int count = 0;

        foreach (char c in str.ToLower())
        {
            if (vowels.Contains(c))
                count++;
        }

        return count;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();

        int result = text.CountVowels();

        Console.WriteLine("Количество гласных: " + result);

        Console.ReadLine();
    }
}