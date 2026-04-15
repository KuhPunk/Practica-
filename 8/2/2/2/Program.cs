using System;

class MyList<T>
{
    private T[] items;
    private int count;

    public int Count
    {
        get { return count; }
    }

    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }

        items[count] = item;
        count++;
    }

    public bool Remove(T item)
    {
        int index = -1;

        for (int i = 0; i < count; i++)
        {
            if (Equals(items[i], item))
            {
                index = i;
                break;
            }
        }

        if (index == -1)
            return false;

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[count - 1] = default(T);
        count--;

        return true;
    }

    public T Find(Predicate<T> predicate)
    {
        for (int i = 0; i < count; i++)
        {
            if (predicate(items[i]))
            {
                return items[i];
            }
        }

        return default(T);
    }

    public void Sort(Comparison<T> comparison)
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (comparison(items[j], items[j + 1]) > 0)
                {
                    T temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }

    public T GetAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException("Неверный индекс");

        return items[index];
    }

    public void ShowAll()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }

    private void Resize()
    {
        T[] newItems = new T[items.Length * 2];

        for (int i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }

        items = newItems;
    }
}

class ListManager<T>
{
    private MyList<T> list;

    public ListManager()
    {
        list = new MyList<T>();
    }

    public void AddItem(T item)
    {
        list.Add(item);
    }

    public void RemoveItem(T item)
    {
        if (list.Remove(item))
            Console.WriteLine("Элемент удалён");
        else
            Console.WriteLine("Элемент не найден");
    }

    public void FindItem(Predicate<T> predicate)
    {
        T result = list.Find(predicate);

        if (!Equals(result, default(T)))
            Console.WriteLine("Найден элемент: " + result);
        else
            Console.WriteLine("Элемент не найден");
    }

    public void SortItems(Comparison<T> comparison)
    {
        list.Sort(comparison);
        Console.WriteLine("Список отсортирован");
    }

    public void ShowItems()
    {
        Console.WriteLine("Элементы списка:");
        list.ShowAll();
    }
}

class Program
{
    static void Main()
    {
        ListManager<int> manager = new ListManager<int>();

        manager.AddItem(5);
        manager.AddItem(2);
        manager.AddItem(9);
        manager.AddItem(1);

        manager.ShowItems();

        manager.SortItems((x, y) => x.CompareTo(y));
        manager.ShowItems();

        manager.FindItem(x => x > 4);

        manager.RemoveItem(2);
        manager.ShowItems();

        Console.ReadLine();
    }
}