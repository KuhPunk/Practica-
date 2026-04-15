using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите N (1 <= N <= 10): ");
        int N = int.Parse(Console.ReadLine());

        int sum = 0;

        for (int i = N; i <= 2 * N; i++)
        {
            sum += i * i;
        }

        Console.WriteLine("Сумма = " + sum);

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}