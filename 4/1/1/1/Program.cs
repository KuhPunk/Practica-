using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        long result = CalculateFactorial(number);

        Console.WriteLine($"Факториал {number} = {result}");

        Console.ReadLine();
    }
    public static long CalculateFactorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Факториал определён только для неотрицательных чисел.");
        }

        long factorial = 1;

        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}