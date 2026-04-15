using System;

namespace AvaloniaApplication1.Models;

public class ChatMessageModel
{
    public string User { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Time { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"[{Time:HH:mm}] {User}: {Message}";
    }
}