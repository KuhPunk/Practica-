using System;

class A
{
    private int a;
    private int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public int Sum()
    {
        return a + b;
    }

    public double CalculateExpression()
    {
        if (a == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
            return 0;
        }

        return Math.Sin(b) / (3 * a);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine());

        A obj = new A(a, b);

        Console.WriteLine($"\nСумма a + b = {obj.Sum()}");
        Console.WriteLine($"sin(b) / (3a) = {obj.CalculateExpression()}");

        Console.ReadLine();
    }
}