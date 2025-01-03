using Business.Models;
using Business.Services;

namespace BusinessTests.Services;

public class ContactService_Tests
{
    // Sökväg till testmappen
    private readonly string testDirectory = @"c:\projekt";
    // Filnamn för testfilen
    private readonly string testFileName = "contacts.json";
    // Instanser av FileService och ContactService
    private readonly FileService _fileService;
    private readonly ContactService _contactService;

    // Konstruktor som skapar testmappen och instanser av FileService och ContactService.
    public ContactService_Tests()
    {
        // Säkerställ att testmappen finns.
        if (!Directory.Exists(testDirectory))
        {
            Directory.CreateDirectory(testDirectory);
        }

        // Skapa instans av FileService och ContactService.
        _fileService = new FileService(testDirectory, testFileName);
        _contactService = new ContactService();
    }

    // Testar att lägga till en kontakt och spara till fil.
    [Fact]
    public void Add_ShouldAddContactAndSaveToFile()
    {
        // Arrange
        var contact = new Contact { FirstName = "John", PhoneNumber = "123456789" };

        // Act
        _contactService.Add(contact);

        // Assert
        var contactsFromFile = _fileService.LoadListFromFile();
        Assert.Contains(contactsFromFile, c => c.FirstName == "John" && c.PhoneNumber == "123456789");
    }

    // Testar att hämta alla kontakter från fil.
    [Fact]
    public void GetAll_ShouldReturnAllContactsFromFile()
    {
        // Arrange
        var contact1 = new Contact { FirstName = "John", PhoneNumber = "123456789" };
        var contact2 = new Contact { FirstName = "Jane", PhoneNumber = "987654321" };
        _contactService.Add(contact1);
        _contactService.Add(contact2);

        // Act
        var allContacts = _contactService.GetAll().ToList();

        // Assert
        Assert.Equal(2, allContacts.Count);
        Assert.Contains(allContacts, c => c.FirstName == "John" && c.PhoneNumber == "123456789");
        Assert.Contains(allContacts, c => c.FirstName == "Jane" && c.PhoneNumber == "987654321");
    }

    // Rensar testmappen.
    [Fact]
    public void Dispose()
    {
        var filePath = Path.Combine(testDirectory, testFileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
