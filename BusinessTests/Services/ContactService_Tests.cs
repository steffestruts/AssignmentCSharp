using Business.Models;
using Business.Services;

namespace BusinessTests.Services;

public class ContactService_Tests
{
    // Tom lista av kontakter
    private List<Contact> _contacts = new List<Contact>();
    // Instansierar FileService med sökväg och filnamn
    private readonly FileService _fileServiceTest = new(@"c:\projekt\assignmentcsharptest", "contacts-test.json");

    // Testar att Add-metoden lägger till en kontakt i listan och sparar listan till en fil.
    [Fact]
    public void Add_ShouldCreateContact()
    {
        // Arrange
        var contactService = new ContactService();

        // Act
        var newContact = new Contact { FirstName = "Jane", LastName = "Doe", Address = "Okänt", City = "Okänt", PostalCode = "12345", PhoneNumber = "123456789", Email = "jane.doe@domain.com" };

        // Assert
        contactService.Add(newContact);
    }

    // Testar att GetAll-metoden hämtar alla kontakter från filen.
    [Fact]
    public void GetAll_ShouldGetAllContacts()
    {
        // Arrange
        var contactService = new ContactService();

        // Act
        var allContacts = contactService.GetAll();

        // Assert
        Assert.Contains(allContacts, c => c.FirstName == "Jane" && c.Email == "jane.doe@domain.com");
    }
}
