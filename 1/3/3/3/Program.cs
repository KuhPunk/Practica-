using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите K: ");
        int K = int.Parse(Console.ReadLine());

        Console.Write("Введите N: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            Console.Write(K + " ");
        }

        Console.WriteLine("\nНажмите Enter для выхода...");
        Console.ReadLine();
    }
}