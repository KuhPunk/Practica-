using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите размер матрицы N (<10): ");
        int N = int.Parse(Console.ReadLine());


        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, N];
        Random rnd = new Random();


        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = rnd.Next(a, b + 1);
            }
        }


        Console.WriteLine("\nИсходная матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int positiveCount = 0;

        Console.WriteLine("\nСуммы строк:");


        for (int i = 0; i < N; i++)
        {
            int sumRow = 0;

            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] > 0)
                    positiveCount++;

                sumRow += matrix[i, j];
            }

            Console.WriteLine($"Сумма строки {i}: {sumRow}");
        }

        Console.WriteLine($"\nКоличество положительных элементов: {positiveCount}");

      
        Console.ReadLine();
    }
}