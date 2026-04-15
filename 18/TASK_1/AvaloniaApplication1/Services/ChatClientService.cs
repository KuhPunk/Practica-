using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Services;

public class ChatClientService
{
    private const string PipeName = "WarehouseChatPipe";

    public async Task<bool> SendMessageAsync(string message)
    {
        try
        {
            await using var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out);
            await client.ConnectAsync(2000);

            await using var writer = new StreamWriter(client) { AutoFlush = true };
            await writer.WriteLineAsync(message);

            return true;
        }
        catch
        {
            return false;
        }
    }
}