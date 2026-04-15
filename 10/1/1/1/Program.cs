using System;
using System.Collections.Generic;

class Logger
{
    private static Logger instance;

    private List<string> logs = new List<string>();

    
    private Logger() { }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(string message)
    {
        logs.Add(message);
    }

    public void ShowLogs()
    {
        Console.WriteLine("Логи:");
        foreach (string log in logs)
        {
            Console.WriteLine(log);
        }
    }
}

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("Запуск программы");
        logger2.Log("Пользователь вошёл в систему");
        logger1.Log("Ошибка подключения");

        logger1.ShowLogs();

        Console.ReadLine();
    }
}