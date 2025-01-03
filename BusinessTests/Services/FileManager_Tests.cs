using Business.Services;

namespace BusinessTests.Services;

public class FileManager_Tests
{
    // Sökväg till testfilen
    private string testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "testfile.txt");
    // Sökväg till testmappen
    private string testDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "testdirectory");

    // Testar att skriva innehållet till en fil
    [Fact]
    public void WriteToFile_ShouldWriteContentToFile()
    {
        // Arrange
        var content = "This is a test content.";
        var fileOps = new FileManager();

        // Act
        fileOps.WriteToFile(testFilePath, content);

        // Assert
        Assert.True(File.Exists(testFilePath));
        var fileContent = File.ReadAllText(testFilePath);
        Assert.Equal(content, fileContent);
    }

    // Testar att läsa innehållet från en fil
    [Fact]
    public void ReadFromFile_ShouldReturnCorrectContent()
    {
        // Arrange
        var content = "This is another test content.";
        var fileOps = new FileManager();
        File.WriteAllText(testFilePath, content);

        // Act
        var result = fileOps.ReadFromFile(testFilePath);

        // Assert
        Assert.Equal(content, result);
    }

    // Testar att kontrollera om en fil existerar
    [Fact]
    public void FileExists_ShouldReturnTrueIfFileExists()
    {
        // Arrange
        var fileOps = new FileManager();
        File.WriteAllText(testFilePath, "Temporary file for testing.");

        // Act
        var result = fileOps.FileExists(testFilePath);

        // Assert
        Assert.True(result);
    }

    // Testar att kontrollera om en fil inte existerar
    [Fact]
    public void FileExists_ShouldReturnFalseIfFileDoesNotExist()
    {
        // Arrange
        var fileOps = new FileManager();

        // Act
        var result = fileOps.FileExists(testFilePath);

        // Assert
        Assert.False(result);
    }

    // Testar att skapa en mapp om den inte existerar
    [Fact]
    public void CreateDirectoryIfNotExists_ShouldCreateDirectory()
    {
        // Arrange
        var fileOps = new FileManager();

        // Act
        fileOps.CreateDirectoryIfNotExists(testDirectoryPath);

        // Assert
        Assert.True(Directory.Exists(testDirectoryPath));

        // Clean up
        Directory.Delete(testDirectoryPath);
    }

    // Rensar upp efter testerna
    public FileManager_Tests()
    {
        // Ser till att testfilen inte existerar innan varje test
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }

        // Ser till att testmappen inte existerar innan varje test
        if (Directory.Exists(testDirectoryPath))
        {
            Directory.Delete(testDirectoryPath);
        }
    }
}
