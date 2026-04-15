using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Введите число: ");
            double a = double.Parse(Console.ReadLine());

            double b;
            PowerA3(a, out b);

            Console.WriteLine("Куб числа = " + b);
            Console.WriteLine();
        }

        Console.ReadLine();
    }

    static void PowerA3(double A, out double B)
    {
        B = A * A * A;
    }
}