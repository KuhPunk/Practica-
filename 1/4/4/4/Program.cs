using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());

        double y;

        if (x < 1)
        {
            y = 1;
        }
        else if (x <= 2)
        {
            y = x * x * Math.Log(x);
        }
        else
        {
            y = Math.Exp(2 * x) * Math.Cos(5 * x);
        }

        Console.WriteLine("y = " + y);

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}