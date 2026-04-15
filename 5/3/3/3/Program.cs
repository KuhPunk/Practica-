using System;


class Animal
{
    public string Name;

    public Animal(string name)
    {
        Name = name;
    }

    public virtual void Show()
    {
        Console.WriteLine("Животное: " + Name);
    }
}


interface ICanFly
{
    void Fly();
}

interface ICanSwim
{
    void Swim();
}


class Bird : Animal, ICanFly
{
    public Bird(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine(Name + " летает");
    }

    public override void Show()
    {
        Console.WriteLine("Птица: " + Name);
    }
}


class Fish : Animal, ICanSwim
{
    public Fish(string name) : base(name) { }

    public void Swim()
    {
        Console.WriteLine(Name + " плавает");
    }

    public override void Show()
    {
        Console.WriteLine("Рыба: " + Name);
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Bird("Орел"),
            new Fish("Карп"),
            new Bird("Воробей"),
            new Fish("Щука")
        };

        Console.WriteLine("Все животные:\n");
        foreach (var a in animals)
        {
            a.Show();
        }

        Console.WriteLine("\nТе, кто умеет летать:\n");

        foreach (var a in animals)
        {
            if (a is ICanFly)
            {
                a.Show();
            }
        }

        Console.ReadLine();
    }
}