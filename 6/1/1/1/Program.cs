using System;


delegate void MessageHandler(string message);


class ConsoleLogger
{
    public void Log(string message)
    {
        Console.WriteLine("Console: " + message);
    }
}


class FileLogger
{
    public void Log(string message)
    {
        
        Console.WriteLine("File: " + message);
    }
}

class Program
{
    static void Main()
    {
        ConsoleLogger consoleLogger = new ConsoleLogger();
        FileLogger fileLogger = new FileLogger();

       
        MessageHandler handler = consoleLogger.Log;
        handler += fileLogger.Log;

        handler("Привет, делегаты!");

        Console.ReadLine();
    }
}