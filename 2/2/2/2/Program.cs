using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[100];
        Random rnd = new Random();

     
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(0, 100);
        }

        Console.WriteLine("Массив в обратном порядке:");

        int count = 0;
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + "\t");
            count++;

            if (count % 6 == 0)
                Console.WriteLine();
        }

        Array.Sort(arr);

        Console.WriteLine("\n\nОтсортированный массив:");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }

        Console.Write("\n\nВведите число для поиска: ");
        int k = int.Parse(Console.ReadLine());

        int left = 0;
        int right = arr.Length - 1;
        int index = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == k)
            {
                index = mid;
                break;
            }
            else if (arr[mid] < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        if (index != -1)
            Console.WriteLine($"Число найдено на позиции {index}");
        else
            Console.WriteLine("Число не найдено");

        Console.ReadLine();
    }
}