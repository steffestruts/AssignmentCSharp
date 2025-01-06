using Business.Models;
using Business.Services;
using System;

namespace BusinessTests.Services;

public class JsonSerializerService_Tests
{
    // Testar att serialisera objekt till JSON-korrekt
    [Fact]
    public void SerializeToJson_ShouldSerializeObjectCorrectly()
    {
        // Arrange
        var service = new JsonSerializerService();
        var testObject = new Contact
        {
            FirstName = "Jane",
            LastName = "Doe"
        };

        // Act
        string json = service.SerializeToJson(testObject);

        // Assert
        Assert.Contains("\"FirstName\": \"Jane\"", json);
        Assert.Contains("\"LastName\": \"Doe\"", json);
    }

    // Testar att deserialisera JSON-korrekt
    [Fact]
    public void DeserializeFromJson_ShouldDeserializeJsonCorrectly()
    {
        // Arrange
        var service = new JsonSerializerService();
        string json = "{\"FirstName\": \"Jane\", \"LastName\": \"Doe\"}";

        // Act
        var contact = service.DeserializeFromJson<Contact>(json);

        // Assert
        Assert.NotNull(contact);
        Assert.Equal("Jane", contact?.FirstName);
        Assert.Equal("Doe", contact?.LastName);
    }
}
