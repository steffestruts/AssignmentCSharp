namespace Business.Services;

/* Detta är genererat av Chat GPT 4o - Koden kollar om JSON-filen finns, annars skapar den den. */

public class FileHandler
{
    // De tre första metoderna har jag gjort till expression bodies för att göra koden mer kompakt. Förslag av Visual Studio. Var Block Body innan.
    // Kollar om filen finns
    public bool FileExists(string path) => File.Exists(path);

    // Skriver till filen
    public void WriteToFile(string path, string content) => File.WriteAllText(path, content);

    // Läser från filen
    public string ReadFromFile(string path) => File.ReadAllText(path);

    // Tänkte göra "extract base class" på metoden men förstod inte varför Visual Studio förslog det men kommer troligen gör det.
    // Skapar mappen om den inte finns
    public void CreateDirectoryIfNotExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
}
