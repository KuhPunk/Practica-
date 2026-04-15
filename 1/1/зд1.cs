using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите расстояние в сантиметрах: ");
        int cm = int.Parse(Console.ReadLine());

        int meters = cm / 100;

        Console.WriteLine("Число полных метров: " + meters);

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine(); 
    }
}