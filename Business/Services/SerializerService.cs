using System.Text.Json;

namespace Business.Services;

/* Detta är genererat av Chat GPT 4o - Koden gör se/de -rialisering av den sparade filen, som är sparad som en JSON-fil. */

public class SerializerService
{
    private readonly JsonSerializerOptions _serializerOptions;

    // Konstruktor
    public SerializerService()
    {
        _serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    // Serialiserar objekt till JSON
    public string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, _serializerOptions);
    }

    // Deserialiserar JSON till objekt
    public T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _serializerOptions);
    }
}
