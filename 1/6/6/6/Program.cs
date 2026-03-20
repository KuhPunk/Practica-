using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество баллов (0-100): ");
        int score = int.Parse(Console.ReadLine());

        if (score >= 90 && score <= 100)
        {
            Console.WriteLine("Отлично");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Хорошо");
        }
        else if (score >= 50)
        {
            Console.WriteLine("Удовлетворительно");
        }
        else if (score >= 0)
        {
            Console.WriteLine("Неудовлетворительно");
        }
        else
        {
            Console.WriteLine("Некорректный ввод");
        }

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}