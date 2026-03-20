using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double b = double.Parse(Console.ReadLine());

        double max;

        if (a > b)
        {
            max = a;
        }
        else
        {
            max = b;
        }

        Console.WriteLine("Максимальное значение: " + max);

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}