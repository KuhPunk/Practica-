using System;
using System.Collections.Generic;

interface IRepository<T>
{
    void Add(T item);
    bool Remove(T item);
    IEnumerable<T> GetAll();
}

class MemoryRepository<T> : IRepository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public bool Remove(T item)
    {
        return items.Remove(item);
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }
}

class RepositoryManager<T>
{
    private IRepository<T> repository;

    public RepositoryManager(IRepository<T> repository)
    {
        this.repository = repository;
    }

    public void DisplayAll()
    {
        foreach (T item in repository.GetAll())
        {
            Console.WriteLine(item);
        }
    }

    public T Find(Func<T, bool> predicate)
    {
        foreach (T item in repository.GetAll())
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default(T);
    }

    public void AddItem(T item)
    {
        repository.Add(item);
    }

    public void RemoveItem(T item)
    {
        if (repository.Remove(item))
            Console.WriteLine("Элемент удалён");
        else
            Console.WriteLine("Элемент не найден");
    }
}

class Program
{
    static void Main()
    {
        MemoryRepository<string> repo = new MemoryRepository<string>();
        RepositoryManager<string> manager = new RepositoryManager<string>(repo);

        manager.AddItem("Иван");
        manager.AddItem("Петр");
        manager.AddItem("Анна");

        Console.WriteLine("Все элементы:");
        manager.DisplayAll();

        string found = manager.Find(x => x.StartsWith("П"));

        Console.WriteLine();
        if (found != null)
            Console.WriteLine("Найден элемент: " + found);
        else
            Console.WriteLine("Элемент не найден");

        Console.WriteLine();
        manager.RemoveItem("Петр");

        Console.WriteLine("\nПосле удаления:");
        manager.DisplayAll();

        Console.ReadLine();
    }
}