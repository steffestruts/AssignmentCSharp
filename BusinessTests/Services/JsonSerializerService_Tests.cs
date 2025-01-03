using Business.Models;
using Business.Services;
using System;

namespace BusinessTests.Services;

public class JsonSerializerService_Tests
{
    [Fact]
    public void SerializeToJson_ShouldSerializeObjectCorrectly()
    {
        // Arrange
        var service = new JsonSerializerService();
        var testObject = new Contact
        {
            FirstName = "John",
            LastName = "Doe"
        };

        // Act
        string json = service.SerializeToJson(testObject);

        // Assert
        Assert.Contains("\"FirstName\": \"John\"", json);
        Assert.Contains("\"LastName\": \"Doe\"", json);
    }

    [Fact]
    public void DeserializeFromJson_ShouldDeserializeJsonCorrectly()
    {
        // Arrange
        var service = new JsonSerializerService();
        string json = "{\"FirstName\": \"John\", \"LastName\": \"Doe\"}";

        // Act
        var contact = service.DeserializeFromJson<Contact>(json);

        // Assert
        Assert.NotNull(contact);
        Assert.Equal("John", contact?.FirstName);
        Assert.Equal("Doe", contact?.LastName);
    }
}
