using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        StringBuilder sb = new StringBuilder("мир");

        Console.Write("Введите строку для добавления в начало: ");
        string prefix = Console.ReadLine();


        sb.Insert(0, prefix);

        Console.WriteLine("Результат StringBuilder:");
        Console.WriteLine(sb);

 
        Console.Write("\nВведите строку для проверки (только цифры?): ");
        string input = Console.ReadLine();


        bool isDigitsOnly = Regex.IsMatch(input, @"^\d+$");

        if (isDigitsOnly)
            Console.WriteLine("Строка содержит только цифры");
        else
            Console.WriteLine("Строка содержит НЕ только цифры");

        Console.ReadLine();
    }
}