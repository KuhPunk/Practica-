using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[15];
        Random rnd = new Random();

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(0, 100);
            Console.Write(arr[i] + " ");
        }

    
        int max = arr[0];
        int maxIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }
        int temp = arr[0];
        arr[0] = arr[maxIndex];
        arr[maxIndex] = temp;
        Console.WriteLine("\n\nМассив после обмена:");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }

      
        Console.ReadLine();
    }
}