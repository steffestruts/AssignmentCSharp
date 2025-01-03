using Business.Models;

namespace BusinessTests.Models;

public class Contact_Tests
{
    // Testar om Contact-objektet fungerar korrekt
    [Fact]
    public void Contact_ShouldCorrectlyWorking()
    {
        // Arrange
        var contact = new Contact
        {
            FirstName = "Herr",
            LastName = "Karlsson",
            Email = "herr.karlsson@domain.com",
            PhoneNumber = "1234567890",
            Address = "Karlsson På Taket",
            PostalCode = "12345",
            City = "Stadholm"
        };

        // Act
        var firstName = contact.FirstName;
        var lastName = contact.LastName;
        var email = contact.Email;
        var phoneNumber = contact.PhoneNumber;
        var address = contact.Address;
        var postalCode = contact.PostalCode;
        var city = contact.City;

        // Assert
        Assert.Equal("Herr", firstName);
        Assert.Equal("Karlsson", lastName);
        Assert.Equal("herr.karlsson@domain.com", email);
        Assert.Equal("1234567890", phoneNumber);
        Assert.Equal("Karlsson På Taket", address);
        Assert.Equal("12345", postalCode);
        Assert.Equal("Stadholm", city);
    }

    // Testar om Contact-objektet har ett unikt Id
    [Fact]
    public void Contact_ShouldHaveAUniqueId()
    {
        // Arrange
        var contact1 = new Contact();
        var contact2 = new Contact();

        // Act
        var id1 = contact1.Id;
        var id2 = contact2.Id;

        // Assert
        Assert.NotEqual(id1, id2);
    }
}
