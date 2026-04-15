using System;

interface ISortingStrategy
{
    void Sort(int[] array);
}


class BubbleSort : ISortingStrategy
{
    public void Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("BubbleSort выполнен");
    }
}


class QuickSort : ISortingStrategy
{
    public void Sort(int[] array)
    {
        Quick(array, 0, array.Length - 1);
        Console.WriteLine("QuickSort выполнен");
    }

    private void Quick(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int pivot = arr[(left + right) / 2];
        int i = left, j = right;

        while (i <= j)
        {
            while (arr[i] < pivot) i++;
            while (arr[j] > pivot) j--;

            if (i <= j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }

        Quick(arr, left, j);
        Quick(arr, i, right);
    }
}


class MergeSort : ISortingStrategy
{
    public void Sort(int[] array)
    {
        Merge(array, 0, array.Length - 1);
        Console.WriteLine("MergeSort выполнен");
    }

    private void Merge(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int mid = (left + right) / 2;

        Merge(arr, left, mid);
        Merge(arr, mid + 1, right);

        MergeArrays(arr, left, mid, right);
    }

    private void MergeArrays(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];

        int i = left, j = mid + 1, k = 0;

        while (i <= mid && j <= right)
        {
            if (arr[i] < arr[j])
                temp[k++] = arr[i++];
            else
                temp[k++] = arr[j++];
        }

        while (i <= mid)
            temp[k++] = arr[i++];

        while (j <= right)
            temp[k++] = arr[j++];

        for (int t = 0; t < temp.Length; t++)
        {
            arr[left + t] = temp[t];
        }
    }
}

class ArraySorter
{
    private ISortingStrategy strategy;

    public void SetStrategy(ISortingStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void Sort(int[] array)
    {
        strategy.Sort(array);
    }
}

class Program
{
    static void Main()
    {
        int[] array = { 5, 2, 9, 1, 3 };

        ArraySorter sorter = new ArraySorter();

   
        sorter.SetStrategy(new BubbleSort());
        sorter.Sort(array);

        Console.WriteLine("Результат:");
        Print(array);

       
        int[] array2 = { 5, 2, 9, 1, 3 };

        sorter.SetStrategy(new QuickSort());
        sorter.Sort(array2);

        Console.WriteLine("Результат:");
        Print(array2);

        Console.ReadLine();
    }

    static void Print(int[] array)
    {
        foreach (int x in array)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}