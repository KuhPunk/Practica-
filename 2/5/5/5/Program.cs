using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());

        int[][] arr = new int[n][];
        Random rnd = new Random();


        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите длину строки {i}: ");
            int m = int.Parse(Console.ReadLine());

            arr[i] = new int[m];


            for (int j = 0; j < m; j++)
            {
                arr[i][j] = rnd.Next(1, 10);
            }
        }


        Console.WriteLine("\nИсходный массив:");
        for (int i = 0; i < n; i++)
        {
            foreach (int x in arr[i])
                Console.Write(x + " ");
            Console.WriteLine();
        }


        for (int i = 0; i < n; i++)
        {
            int sum = 0;


            for (int j = 0; j < arr[i].Length; j++)
            {
                sum += arr[i][j];
            }


            for (int j = 0; j < arr[i].Length; j++)
            {
                arr[i][j] = sum;
            }
        }

        Console.WriteLine("\nПосле обработки:");
        for (int i = 0; i < n; i++)
        {
            foreach (int x in arr[i])
                Console.Write(x + " ");
            Console.WriteLine();
        }


        Console.ReadLine();
    }
}