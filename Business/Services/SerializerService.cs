using System.Text.Json;

namespace Business.Services;

/* Detta är genererat av Chat GPT 4o - Koden gör de/se -rialisering av den sparade filen, som är sparad som en JSON-fil. */

public class SerializerService
{
    private readonly JsonSerializerOptions _serializerOptions;

    public SerializerService()
    {
        _serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, _serializerOptions);
    }

    public T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _serializerOptions);
    }
}
