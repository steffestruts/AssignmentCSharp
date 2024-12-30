using Business.Models;
using System.Diagnostics;

/* Detta är genererat av Chat GPT 4o - Tidigare kod såg ungefär likadan ut. 
 * Använde Chat GPT göra det mer SRP, blev osäker hur gränserna definieras i S för SOLID */

namespace Business.Services
{
    public class FileService
    {
        private readonly string _directoryPath;
        private readonly string _filePath;
        private readonly FileManager _fileManager;
        private readonly JsonSerializerService _jsonSerializerService;

        public FileService(string directoryPath = "Data", string fileName = "contacts.json")
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(_directoryPath, fileName);
            _fileManager = new FileManager();
            _jsonSerializerService = new JsonSerializerService();
        }

        public void SaveListToFile(List<Contact> list)
        {
            try
            {
                _fileManager.CreateDirectoryIfNotExists(_directoryPath);
                var json = _jsonSerializerService.SerializeToJson(list);
                _fileManager.WriteToFile(_filePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public List<Contact> LoadListFromFile()
        {
            try
            {
                if (!_fileManager.FileExists(_filePath))
                {
                    return new List<Contact>();
                }

                var json = _fileManager.ReadFromFile(_filePath);
                var list = _jsonSerializerService.DeserializeFromJson<List<Contact>>(json);
                return list ?? new List<Contact>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Contact>();
            }
        }
    }
}
