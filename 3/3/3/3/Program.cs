using System;

abstract class Transport
{
    public string Model { get; set; }
    public int MaxSpeed { get; set; }
    public double FuelConsumption { get; set; }

    public Transport(string model, int maxSpeed, double fuelConsumption)
    {
        Model = model;
        MaxSpeed = maxSpeed;
        FuelConsumption = fuelConsumption;
    }

    public abstract void ShowInfo();
}

sealed class Car : Transport
{
    public int PassengerCount { get; set; }

    public Car(string model, int maxSpeed, double fuelConsumption, int passengerCount)
        : base(model, maxSpeed, fuelConsumption)
    {
        PassengerCount = passengerCount;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Легковой автомобиль: {Model}, Макс. скорость: {MaxSpeed}, Расход топлива: {FuelConsumption}, Пассажиров: {PassengerCount}");
    }
}

sealed class Truck : Transport
{
    public double LoadCapacity { get; set; }

    public Truck(string model, int maxSpeed, double fuelConsumption, double loadCapacity)
        : base(model, maxSpeed, fuelConsumption)
    {
        LoadCapacity = loadCapacity;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Грузовик: {Model}, Макс. скорость: {MaxSpeed}, Расход топлива: {FuelConsumption}, Грузоподъемность: {LoadCapacity}");
    }
}

class TransportManager
{
    private Transport[] transports;
    private int count;

    public TransportManager(int size)
    {
        transports = new Transport[size];
        count = 0;
    }

    public void AddTransport(Transport transport)
    {
        if (count < transports.Length)
        {
            transports[count] = transport;
            count++;
        }
        else
        {
            Console.WriteLine("Массив транспорта заполнен.");
        }
    }

    public void ShowAllTransport()
    {
        Console.WriteLine("Список транспорта:");
        for (int i = 0; i < count; i++)
        {
            transports[i].ShowInfo();
        }
    }

    public Transport GetMostEfficientVehicle()
    {
        if (count == 0)
            return null;

        Transport best = transports[0];

        for (int i = 1; i < count; i++)
        {
            if (transports[i].FuelConsumption < best.FuelConsumption)
            {
                best = transports[i];
            }
        }

        return best;
    }

    public Transport GetFastestVehicle()
    {
        if (count == 0)
            return null;

        Transport fastest = transports[0];

        for (int i = 1; i < count; i++)
        {
            if (transports[i].MaxSpeed > fastest.MaxSpeed)
            {
                fastest = transports[i];
            }
        }

        return fastest;
    }
}

class Program
{
    static void Main()
    {
        TransportManager manager = new TransportManager(5);

        manager.AddTransport(new Car("Toyota Camry", 210, 7.5, 5));
        manager.AddTransport(new Truck("Volvo FH", 180, 25.0, 20));
        manager.AddTransport(new Car("Honda Civic", 200, 6.8, 5));
        manager.AddTransport(new Truck("MAN TGX", 170, 22.5, 18));

        manager.ShowAllTransport();

        Transport efficient = manager.GetMostEfficientVehicle();
        Console.WriteLine("\nСамый экономичный транспорт:");
        if (efficient != null)
            efficient.ShowInfo();

        Transport fastest = manager.GetFastestVehicle();
        Console.WriteLine("\nСамый быстрый транспорт:");
        if (fastest != null)
            fastest.ShowInfo();

        Console.ReadLine();
    }
}