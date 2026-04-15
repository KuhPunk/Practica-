using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        double A = double.Parse(Console.ReadLine());

        Console.Write("Введите B: ");
        double B = double.Parse(Console.ReadLine());

        Console.Write("Введите C: ");
        double C = double.Parse(Console.ReadLine());

        double D = B * B - 4 * A * C;

        if (D >= 0)
        {
            Console.WriteLine("Истина: уравнение имеет вещественные корни");
        }
        else
        {
            Console.WriteLine("Ложь: уравнение не имеет вещественных корней");
        }

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}