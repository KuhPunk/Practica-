using System;

class AgeRestrictionException : Exception
{
    public AgeRestrictionException() { }

    public AgeRestrictionException(string message) : base(message) { }

    public AgeRestrictionException(string message, Exception inner)
        : base(message, inner) { }
}

class UserRegistration
{
    public void RegisterUser(int age)
    {
        if (age < 18)
        {
            throw new AgeRestrictionException("Регистрация доступна только с 18 лет");
        }

        Console.WriteLine("Пользователь успешно зарегистрирован");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            UserRegistration reg = new UserRegistration();
            reg.RegisterUser(age);
        }
        catch (AgeRestrictionException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Другая ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }
}