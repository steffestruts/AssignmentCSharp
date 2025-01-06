using Business.Services;

namespace BusinessTests.Services;

public class FileManager_Tests
{
    // Sökväg till testfilen
    private string testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "testfile.txt");
    // Sökväg till testmappen
    private string testDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "testdirectory");

    [Fact]
    public void WriteToFile_ShouldWriteDataToFile()
    {
        // Arrange
        var fileManager = new FileManager();
        var data = "Test data";
        // Act
        fileManager.WriteToFile(testFilePath, data);
        // Assert
        Assert.True(File.Exists(testFilePath), "Filen borde existera efter att data har skrivits till den.");
        var text = File.ReadAllText(testFilePath);
        Assert.Contains("Test data", text);
    }

    [Fact]
    public void ReadFromFile_ShouldReadDataFromFile()
    {
        // Arrange
        var fileManager = new FileManager();
        var data = "Test data";
        File.WriteAllText(testFilePath, data);
        // Act
        var text = fileManager.ReadFromFile(testFilePath);
        // Assert
        Assert.Contains("Test data", text);
    }

    [Fact]
    public void FileExists_ShouldReturnTrueIfFileExists()
    {
        // Arrange
        var fileManager = new FileManager();
        File.WriteAllText(testFilePath, "Test data");
        // Act
        var fileExists = fileManager.FileExists(testFilePath);
        // Assert
        Assert.True(fileExists, "Filen borde existera.");
    }

    [Fact]
    public void CreateDirectoryIfNotExists_ShouldCreateDirectoryIfNotExists()
    {
        // Arrange
        var fileManager = new FileManager();
        // Act
        fileManager.CreateDirectoryIfNotExists(testDirectoryPath);
        // Assert
        Assert.True(Directory.Exists(testDirectoryPath), "Katalogen borde existera efter att den har skapats.");
    }
}
