using Business.Models;
using Business.Services;

/* Detta är genererat av Chat GPT 4o. 
 * Nedan kod kollar om SaveListToFile-metoden sparar en lista med kontakter till en JSON-fil och LoadListFromFile-metoden laddar en lista med kontakter från en JSON-fil.*/

namespace BusinessTests.Services;

public class FileService_Tests
{
    // Sökväg till testkatalogen
    private readonly string _testDirectoryPath;
    // Sökväg till testfilen
    private readonly string _testFilePath;

    // Konstruktor som förbereder testmiljön
    public FileService_Tests(string testDirectoryPath = "Data", string testFileName = "contacts.json")
    {
        _testDirectoryPath = testDirectoryPath;
        // Slår ihop testDirectoryPath och testFileName till testFilePath
        _testFilePath = Path.Combine(_testDirectoryPath, testFileName);
    }

    // Testar att SaveListToFile-metoden sparar en lista med kontakter till en JSON-fil.
    [Fact]
    public void SaveListToFile_ShouldCreateFileAndSaveData()
    {
        // Arrange
        var fileService = new FileService(_testDirectoryPath, "contacts.json");
        var contactList = new List<Contact>
            {
                new() { FirstName = "Jane", LastName = "Doe", Address = "Okänt", City = "Okänt", PostalCode = "12345", Email = "jane.doe@domain.com" },
            };

        // Act
        fileService.SaveListToFile(contactList);

        // Assert
        Assert.True(File.Exists(_testFilePath), "Filen borde existera efter att data har sparats.");
        var json = File.ReadAllText(_testFilePath);
        Assert.Contains("Jane", json);
    }

    // Testar att LoadListFromFile-metoden laddar en lista med kontakter från en JSON-fil.
    [Fact]
    public void LoadListFromFile_ShouldLoadDataFromFile()
    {
        // Arrange
        var fileService = new FileService(_testDirectoryPath, "contacts.json");
        var contactList = new List<Contact>
            {
                new() { FirstName = "Jane", LastName = "Doe", Address = "Okänt", City = "Okänt", PostalCode = "12345", Email = "jane.doe@domain.com" }
            };
        fileService.SaveListToFile(contactList);

        // Act
        var loadedContacts = fileService.LoadListFromFile();

        // Assert
        Assert.NotNull(loadedContacts);
        Assert.Single(loadedContacts);
        Assert.Contains(loadedContacts, c => c.FirstName == "Jane");
    }
}
