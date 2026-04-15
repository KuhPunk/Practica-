using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 101; i += 2)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\nНажмите Enter для выхода...");
        Console.ReadLine();
    }
}