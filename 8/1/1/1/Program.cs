using System;
using System.Collections;

class Command
{
    public string Description;

    public Command(string description)
    {
        Description = description;
    }
}

class CommandManager
{
    private Stack executedCommands = new Stack();
    private Stack undoneCommands = new Stack();

    public void Execute(Command command)
    {
        executedCommands.Push(command);
        undoneCommands.Clear();

        Console.WriteLine("Выполнено: " + command.Description);
    }

    public void Undo()
    {
        if (executedCommands.Count == 0)
        {
            Console.WriteLine("Нет команд для отмены");
            return;
        }

        Command command = (Command)executedCommands.Pop();
        undoneCommands.Push(command);

        Console.WriteLine("Отменено: " + command.Description);
    }

    public void Redo()
    {
        if (undoneCommands.Count == 0)
        {
            Console.WriteLine("Нет команд для повтора");
            return;
        }

        Command command = (Command)undoneCommands.Pop();
        executedCommands.Push(command);

        Console.WriteLine("Повторно выполнено: " + command.Description);
    }

    public void ShowExecuted()
    {
        Console.WriteLine("\nВыполненные команды:");
        foreach (Command command in executedCommands)
        {
            Console.WriteLine(command.Description);
        }
    }

    public void ShowUndone()
    {
        Console.WriteLine("\nОтмененные команды:");
        foreach (Command command in undoneCommands)
        {
            Console.WriteLine(command.Description);
        }
    }
}

class Program
{
    static void Main()
    {
        CommandManager manager = new CommandManager();

        Command c1 = new Command("Открыть файл");
        Command c2 = new Command("Сохранить файл");
        Command c3 = new Command("Удалить строку");

        manager.Execute(c1);
        manager.Execute(c2);
        manager.Execute(c3);

        manager.Undo();
        manager.Undo();

        manager.Redo();

        manager.ShowExecuted();
        manager.ShowUndone();

        Console.ReadLine();
    }
}