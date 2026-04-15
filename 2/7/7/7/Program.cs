using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первую строку: ");
        string str1 = Console.ReadLine();

        Console.Write("Введите вторую строку: ");
        string str2 = Console.ReadLine();

       
        string result = string.Concat(str1, str2);

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(result);

 
        Console.ReadLine();
    }
}