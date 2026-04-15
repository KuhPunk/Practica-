using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите количество строк N: ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов M: ");
        int M = int.Parse(Console.ReadLine());

        int[,] arr = new int[N, M];
        Random rnd = new Random();


        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                arr[i, j] = rnd.Next(1, 10); 
            }
        }


        Console.WriteLine("\nМассив:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }

  
        if (M < 2)
        {
            Console.WriteLine("\nВторого столбца не существует!");
        }
        else
        {
            int product = 1;


            for (int i = 0; i < N; i++)
            {
                product *= arr[i, 1];
            }

            Console.WriteLine($"\nПроизведение элементов второго столбца: {product}");

       
            int absValue = Math.Abs(product);

            if (absValue >= 100 && absValue <= 999)
                Console.WriteLine("Это трёхзначное число");
            else
                Console.WriteLine("Это НЕ трёхзначное число");
        }

 
        Console.ReadLine();
    }
}