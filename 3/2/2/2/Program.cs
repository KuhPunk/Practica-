using System;

class Person
{
    public int Age { get; set; }

    public Person(int age)
    {
        Age = age;
    }
}

static class ArrayUtils
{
    public static int GetMaxValue(Person[] people)
    {
        if (people == null || people.Length == 0)
            throw new ArgumentException("Массив пуст");

        int max = people[0].Age;

        foreach (Person p in people)
        {
            if (p.Age > max)
                max = p.Age;
        }

        return max;
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Person(18),
            new Person(25),
            new Person(56),
            new Person(22)
        };

        int maxAge = ArrayUtils.GetMaxValue(people);

        Console.WriteLine("Максимальный возраст: " + maxAge);

        Console.ReadLine();
    }
}