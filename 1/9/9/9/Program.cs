using System;

class Program
{
    static void Main()
    {
        double A = 0;
        double B = Math.PI / 2;
        int M = 10;

        double H = (B - A) / M;
        double x = A;

        Console.WriteLine("x\t\ty");

        for (int i = 0; i <= M; i++)
        {
            double y = x - Math.Sin(x);
            Console.WriteLine($"{x:F4}\t{y:F4}");
            x += H;
        }

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}