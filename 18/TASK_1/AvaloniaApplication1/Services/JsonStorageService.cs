using System.IO;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Services;

using System.Text.Json;

public class JsonStorageService
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    public async Task<T> LoadAsync<T>(string filePath) where T : new()
    {
        if (!File.Exists(filePath))
        {
            var empty = new T();
            await SaveAsync(filePath, empty);
            return empty;
        }

        var json = await File.ReadAllTextAsync(filePath);
        if (string.IsNullOrWhiteSpace(json))
            return new T();

        var data = JsonSerializer.Deserialize<T>(json, _options);
        return data ?? new T();
    }

    public async Task SaveAsync<T>(string filePath, T data)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        var json = JsonSerializer.Serialize(data, _options);
        await File.WriteAllTextAsync(filePath, json);
    }
}