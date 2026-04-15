using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace AvaloniaApplication1.Services;

public class NotificationService
{
    private readonly string _notificationFilePath =
        Path.Combine(AppContext.BaseDirectory, "Data", "notification.dat");

    public void SendNotification(string message)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_notificationFilePath)!);

        if (!File.Exists(_notificationFilePath))
        {
            using var fs = File.Create(_notificationFilePath);
            fs.SetLength(4096);
        }

        using var mmf = MemoryMappedFile.CreateFromFile(
            _notificationFilePath,
            FileMode.OpenOrCreate,
            mapName: null,
            capacity: 4096);

        using var stream = mmf.CreateViewStream();
        using var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);

        var bytes = Encoding.UTF8.GetBytes(message);

        writer.Write(bytes.Length);
        writer.Write(bytes);
        writer.Flush();
    }

    public string? ReadNotification()
    {
        if (!File.Exists(_notificationFilePath))
            return null;

        using var mmf = MemoryMappedFile.CreateFromFile(
            _notificationFilePath,
            FileMode.OpenOrCreate,
            mapName: null,
            capacity: 4096);

        using var stream = mmf.CreateViewStream();
        using var reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);

        try
        {
            if (stream.Length < 4)
                return null;

            var length = reader.ReadInt32();
            if (length <= 0 || length > 4000)
                return null;

            var bytes = reader.ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            return null;
        }
    }
}