using System.Diagnostics;

/* Detta är genererat av Chat GPT 4o - Tidigare kod såg ungefär likadan ut. 
 * Använde Chat GPT göra det mer SRP, blev osäker hur gränserna definieras i S för SOLID
 * Nedan kod skriver listan till fil och läser filen, allt med try-catch för fånga fel. Resten kollar om filen/mappen finns*/

namespace Business.Services;

public class FileManager
{
    // Skriver innehållet till en fil med try-catch
    public void WriteToFile(string filePath, string content)
    {
        try
        {
            File.WriteAllText(filePath, content);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }

    // Läser innehållet från en fil med try-catch
    public string ReadFromFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }

    // Kontrollerar om en fil existerar
    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    // Skapar en mapp om den inte existerar
    public void CreateDirectoryIfNotExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
}
