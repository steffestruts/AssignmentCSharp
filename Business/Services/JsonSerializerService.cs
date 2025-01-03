using System.Text.Json;

/* Detta är genererat av Chat GPT 4o - Tidigare kod såg ungefär likadan ut. 
 * Använde Chat GPT göra det mer SRP, blev osäker hur gränserna definieras i S för SOLID
 * Nedan är det kod som serialiser objektet till JSON och annan som deserialiserar. Om jag minns rätt så låg denna i FileService tidigare. */

namespace Business.Services
{
    public class JsonSerializerService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        // Instansierar JsonSerializerOptions med indentering
        public JsonSerializerService()
        {
            _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        }

        // Serialiserar data till JSON
        public string SerializeToJson<T>(T data)
        {
            return JsonSerializer.Serialize(data, _jsonSerializerOptions);
        }

        // Deserialiserar data från JSON
        public T? DeserializeFromJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
        }
    }
}
