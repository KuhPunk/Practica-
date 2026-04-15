using System;


interface ISpeaker
{
    void AdjustVolume(int level);
}

interface IMicrophone
{
    void AdjustVolume(int level);
}


class AudioDevice : ISpeaker, IMicrophone
{
    void ISpeaker.AdjustVolume(int level)
    {
        Console.WriteLine("Громкость динамика: " + level);
    }

    void IMicrophone.AdjustVolume(int level)
    {
        Console.WriteLine("Чувствительность микрофона: " + level);
    }
}

class Program
{
    static void Main()
    {
        AudioDevice device = new AudioDevice();

      
        ISpeaker speaker = device;
        IMicrophone mic = device;

        speaker.AdjustVolume(10);
        mic.AdjustVolume(5);

        Console.ReadLine();
    }
}