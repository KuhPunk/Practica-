using System;
using System.IO;

class LogEntry
{
    public DateTime Date;
    public string Message;

    public LogEntry(DateTime date, string message)
    {
        Date = date;
        Message = message;
    }
}

class LogFileWriter
{
    private string filePath = "file.data";

    public void AppendLogEntry(LogEntry entry)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(entry.Date.ToString("dd.MM.yyyy HH:mm:ss") + " - " + entry.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        LogEntry entry1 = new LogEntry(DateTime.Now, "Запуск программы");
        LogEntry entry2 = new LogEntry(DateTime.Now, "Добавлена новая запись");

        LogFileWriter writer = new LogFileWriter();

        writer.AppendLogEntry(entry1);
        writer.AppendLogEntry(entry2);

        Console.WriteLine("Записи добавлены в file.data");

        Console.ReadLine();
    }
}