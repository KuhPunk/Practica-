using System;
using System.IO;

class CustomFileException : Exception
{
    public CustomFileException() { }

    public CustomFileException(string message) : base(message) { }

    public CustomFileException(string message, Exception innerException)
        : base(message, innerException) { }
}

class FileReader
{
    public void ReadFile(string path)
    {
        string text = File.ReadAllText(path);
        Console.WriteLine(text);
    }
}

class FileProcessor
{
    public void ProcessFile(string path)
    {
        FileReader reader = new FileReader();

        try
        {
            reader.ReadFile(path);
        }
        catch (Exception ex)
        {
            throw new CustomFileException("Ошибка при обработке файла", ex);
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string path = "test.txt";

            FileProcessor processor = new FileProcessor();
            processor.ProcessFile(path);
        }
        catch (CustomFileException ex)
        {
            Console.WriteLine("Пользовательское исключение:");
            Console.WriteLine("Сообщение: " + ex.Message);
            Console.WriteLine("Стек вызовов: " + ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("\nВнутреннее исключение:");
                Console.WriteLine("Тип: " + ex.InnerException.GetType().Name);
                Console.WriteLine("Сообщение: " + ex.InnerException.Message);
                Console.WriteLine("Стек вызовов: " + ex.InnerException.StackTrace);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Другая ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }
}