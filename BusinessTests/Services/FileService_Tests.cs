using Business.Models;
using Business.Services;

/* Detta är genererat av Chat GPT 4o. 
 * Nedan kod kollar om SaveListToFile-metoden sparar en lista med kontakter till en JSON-fil och LoadListFromFile-metoden laddar en lista med kontakter från en JSON-fil.*/

namespace BusinessTests.Services;

public class FileService_Tests
{
    // Konstruktor som förbereder testmiljön
    public FileService_Tests()
    {
        // Skapa en sökväg till en testfil
        _testFilePath = Path.Combine(_testDirectoryPath, "contacts.json");

        // Säkerställ att testdata-katalogen finns
        if (Directory.Exists(_testDirectoryPath))
        {
            Directory.Delete(_testDirectoryPath, true);
        }
        Directory.CreateDirectory(_testDirectoryPath);
    }

    // Sökväg till testkatalogen och testfilen
    private readonly string _testDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "TestData");
    // Sökväg till testfilen
    private readonly string _testFilePath;

    // Testar att SaveListToFile-metoden sparar en lista med kontakter till en JSON-fil.
    [Fact]
    public void SaveListToFile_ShouldCreateFileAndSaveData()
    {
        // Arrange
        var fileService = new FileService(_testDirectoryPath, "contacts.json");
        var contactList = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Address = "Okändgatan 1A", City = "", Email = "john@domain.com" },
            };

        // Act
        fileService.SaveListToFile(contactList);

        // Assert
        Assert.True(File.Exists(_testFilePath), "Filen borde existera efter att data har sparats.");
        var json = File.ReadAllText(_testFilePath);
        Assert.Contains("John", json);
    }

    // Testar att LoadListFromFile-metoden laddar en lista med kontakter från en JSON-fil.
    [Fact]
    public void LoadListFromFile_ShouldLoadDataFromFile()
    {
        // Arrange
        var fileService = new FileService(_testDirectoryPath, "contacts.json");
        var contactList = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Address = "Okändgatan 1A", City = "", Email = "john@domain.com" }
            };
        fileService.SaveListToFile(contactList);

        // Act
        var loadedContacts = fileService.LoadListFromFile();

        // Assert
        Assert.NotNull(loadedContacts);
        Assert.Single(loadedContacts);
        Assert.Contains(loadedContacts, c => c.FirstName == "John");
    }

    // Testar att LoadListFromFile-metoden returnerar en tom lista om filen inte existerar.
    [Fact]
    public void LoadListFromFile_ShouldReturnEmptyListIfFileDoesNotExist()
    {
        // Arrange
        var fileService = new FileService(_testDirectoryPath, "nonexistent.json");

        // Act
        var loadedContacts = fileService.LoadListFromFile();

        // Assert
        Assert.Empty(loadedContacts);
    }
}
