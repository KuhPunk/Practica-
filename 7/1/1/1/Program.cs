using System;

class InvalidAgeException : Exception
{
    public InvalidAgeException() { }

    public InvalidAgeException(string message) : base(message) { }

    public InvalidAgeException(string message, Exception inner) : base(message, inner) { }
}

class UserAgeValidator
{
    public void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Возраст должен быть не меньше 18");
        }
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

            UserAgeValidator validator = new UserAgeValidator();
            validator.ValidateAge(age);

            Console.WriteLine("Возраст корректный");
        }
        catch (InvalidAgeException ex)
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