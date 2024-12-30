using System.Text.Json;

/* Detta är genererat av Chat GPT 4o - Tidigare kod såg ungefär likadan ut. 
 * Använde Chat GPT göra det mer SRP, blev osäker hur gränserna definieras i S för SOLID */

namespace Business.Services
{
    public class JsonSerializerService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public JsonSerializerService()
        {
            _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        }

        public string SerializeToJson<T>(T data)
        {
            return JsonSerializer.Serialize(data, _jsonSerializerOptions);
        }

        public T? DeserializeFromJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
        }
    }
}
