namespace Business.Services;

public class FileHandler
{

    // Kollar om filen finns
    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    // Skriver till filen
    public void WriteToFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    // Läser från filen
    public string ReadFromFile(string path)
    {
        return File.ReadAllText(path);
    }

    // Skapar mappen om den inte finns
    public void CreateDirectoryIfNotExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
}
