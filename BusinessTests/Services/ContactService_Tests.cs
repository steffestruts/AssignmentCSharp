namespace BusinessTests.Services;

public class ContactService_Tests
{
    [Fact]
    public void Add_ShouldAddContactToList()
    {
        // Arrange
        var contactService = new ContactService();
        // Act
        var result = contactService.Method();
        // Assert
        Assert.True(result);
    }
}
