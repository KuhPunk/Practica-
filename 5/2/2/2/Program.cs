using System;

// Ассоциация 
class Driver
{
    public string Name;

    public Driver(string name)
    {
        Name = name;
    }
}

// Агрегация
class Wheel
{
    public int Size;

    public Wheel(int size)
    {
        Size = size;
    }
}

// Композиция 
class Engine
{
    public int Power;

    public Engine(int power)
    {
        Power = power;
    }
}

class Car
{
    public string Model;

    // агрегация
    public Wheel[] Wheels;

    // композиция
    private Engine engine;

    // ассоциация
    public Driver Driver;

    public Car(string model, Wheel[] wheels, Driver driver, int enginePower)
    {
        Model = model;
        Wheels = wheels;
        Driver = driver;

        // двигатель создаётся внутри → композиция
        engine = new Engine(enginePower);
    }

    public void Drive()
    {
        if (Driver == null)
        {
            Console.WriteLine(Model + ": нет водителя");
            return;
        }

        Console.WriteLine(Driver.Name + " едет на " + Model +
                          " (мощность: " + engine.Power + ")");
    }
}

class Program
{
    static void Main()
    {
        // общие колёса (агрегация)
        Wheel[] wheels = new Wheel[]
        {
            new Wheel(16),
            new Wheel(16),
            new Wheel(16),
            new Wheel(16)
        };

        // водитель (ассоциация)
        Driver d1 = new Driver("Иван");
        Driver d2 = new Driver("Петр");

        // массив машин
        Car[] cars = new Car[]
        {
            new Car("Toyota", wheels, d1, 150),
            new Car("BMW", wheels, d2, 250),
            new Car("Audi", wheels, null, 200)
        };

        // бизнес-логика
        foreach (Car car in cars)
        {
            car.Drive();
        }

        Console.ReadLine();
    }
}