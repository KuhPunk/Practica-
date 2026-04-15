using System;
using System.Collections.Generic;
using System.IO;

class User
{
    public string Name;
    public int Age;
    public string Email;

    public User(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }
}

class UserFileWriter
{
    private string filePath = "file.data";

    public void WriteUsers(List<User> users)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            foreach (User user in users)
            {
                writer.WriteLine(user.Name + "," + user.Age + "," + user.Email);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        List<User> users = new List<User>
        {
            new User("Иван", 25, "ivan@example.com"),
            new User("Ольга", 30, "olga@example.com"),
            new User("Анна", 22, "anna@example.com")
        };

        UserFileWriter writer = new UserFileWriter();
        writer.WriteUsers(users);

        Console.WriteLine("Данные успешно записаны в file.data");

        Console.ReadLine();
    }
}