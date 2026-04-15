using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());

            long result = Factorial(n);

            Console.WriteLine("Факториал = " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }

    static long Factorial(int n)
    {
        if (n < 0)
            throw new Exception("Число не может быть отрицательным");

        if (n == 0 || n == 1)
            return 1;

        return n * Factorial(n - 1);
    }
}