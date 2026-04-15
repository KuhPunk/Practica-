using System;

abstract class Employee
{
    public string Name;

    public Employee(string name)
    {
        Name = name;
    }

    public abstract double CalculateSalary();

    public virtual void ShowInfo()
    {
        Console.WriteLine("Имя: " + Name);
    }
}

class Manager : Employee
{
    private double salary;
    private double bonus;

    public Manager(string name, double salary, double bonus) : base(name)
    {
        this.salary = salary;
        this.bonus = bonus;
    }

    public override double CalculateSalary()
    {
        return salary + bonus;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Менеджер: " + Name + ", Зарплата: " + CalculateSalary());
    }
}

class Developer : Employee
{
    private double rate;
    private int hours;

    public Developer(string name, double rate, int hours) : base(name)
    {
        this.rate = rate;
        this.hours = hours;
    }

    public override double CalculateSalary()
    {
        return rate * hours;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Разработчик: " + Name + ", Зарплата: " + CalculateSalary());
    }
}

class Intern : Employee
{
    private double stipend;

    public Intern(string name, double stipend) : base(name)
    {
        this.stipend = stipend;
    }

    public override double CalculateSalary()
    {
        return stipend;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Стажёр: " + Name + ", Зарплата: " + CalculateSalary());
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[]
        {
            new Manager("Иван", 50000, 10000),
            new Developer("Петр", 500, 160),
            new Intern("Анна", 20000),
            new Developer("Олег", 600, 150)
        };

        Console.WriteLine("Список сотрудников:\n");

        foreach (Employee emp in employees)
        {
            emp.ShowInfo();
        }

        Console.ReadLine();
    }
}