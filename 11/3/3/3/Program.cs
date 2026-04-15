using System;


interface ICommand
{
    void Execute();
}


class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Свет включен");
    }

    public void TurnOff()
    {
        Console.WriteLine("Свет выключен");
    }
}


class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}


class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}


class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Light light = new Light();

        ICommand lightOn = new LightOnCommand(light);
        ICommand lightOff = new LightOffCommand(light);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(lightOn);
        remote.PressButton();

        remote.SetCommand(lightOff);
        remote.PressButton();

        Console.ReadLine();
    }
}