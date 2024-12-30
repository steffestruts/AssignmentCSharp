using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

/* Detta är genererat av Chat GPT 4o - Tidigare kod såg ungefär likadan ut. 
 * Denna använder SerializerService och Filehandler och "sätter" ihop dessa två filer.
 * SerializerService används för att serialisera och deserialisera JSON-filer.
 * Filehandler används för att skriva och läsa från filer.
 * _directoryPath är sökvägen till mappen där filen ska sparas.
 * Try-catch används för att hantera eventuella fel som kan uppstå i sparandet eller läsandet.
 * Använde Chat GPT göra det mer SRP, blev osäker hur gränserna definieras i S för SOLID */

public class FileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly SerializerService _serializerService;
    private readonly FileHandler _fileHandler;

    public FileService(string directoryPath = "Data", string fileName = "contacts.json")
    {
        // _directoryPath är sökvägen till mappen där filen ska sparas.
        _directoryPath = directoryPath;
        // _filePath är sökvägen till filen som ska sparas.
        _filePath = Path.Combine(_directoryPath, fileName);
        // _serializerService används för att serialisera och deserialisera JSON-filer.
        _serializerService = new SerializerService();
        // _fileHandler används för att skriva och läsa från filer.
        _fileHandler = new FileHandler();
    }

    // SaveListToFile sparar listan med try/catch till en JSON-fil.
    public void SaveListToFile(List<Contact> list)
    {
        try
        {
            _fileHandler.CreateDirectoryIfNotExists(_directoryPath);
            var json = _serializerService.Serialize(list);
            _fileHandler.WriteToFile(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    // LoadListFromFile laddar listan med try/catch från en JSON-fil.
    public List<Contact> LoadListFromFile()
    {
        try
        {
            if (!_fileHandler.FileExists(_filePath))
            {
                return [];
            }

            var json = _fileHandler.ReadFromFile(_filePath);
            var list = _serializerService.Deserialize<List<Contact>>(json);
            return list ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}