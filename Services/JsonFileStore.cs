using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mochi.Services;

public class JsonFileStore
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public static async Task<T?> LoadAsync<T>(string path) where T : class
    {
        if (!File.Exists(path)) return null;

        try
        {
            string json = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<T>(json, Options);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public static async Task SaveAsync<T>(string path, T data) where T : class
    {
        string json = JsonSerializer.Serialize(data, Options);
        await File.WriteAllTextAsync(path, json);
    }
}