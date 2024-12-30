using System.Diagnostics;

/* Detta är genererat av Chat GPT 4o - Tidigare kod såg ungefär likadan ut. 
 * Använde Chat GPT göra det mer SRP, blev osäker hur gränserna definieras i S för SOLID */

namespace Business.Services
{
    public class FileManager
    {
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

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
