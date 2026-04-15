using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public string Name;
    public string Department;
    public double Salary;

    public Employee(string name, string department, double salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }
}

class EmployeeFileWriter
{
    private string filePath = "file.data";

    public void WriteEmployees(List<Employee> employees, char separator)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            foreach (Employee emp in employees)
            {
                writer.WriteLine(emp.Name + separator + emp.Department + separator + emp.Salary);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee("Иван", "IT", 50000),
            new Employee("Ольга", "HR", 60000),
            new Employee("Анна", "Finance", 55000)
        };

        EmployeeFileWriter writer = new EmployeeFileWriter();

        writer.WriteEmployees(employees, '|');

        Console.WriteLine("Данные записаны в file.data");

        Console.ReadLine();
    }
}