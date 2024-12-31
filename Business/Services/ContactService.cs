using Business.Models;

namespace Business.Services;
public class ContactService
{
    private List<Contact> _contacts = [];
    // Instansierar FileService med sökväg (mappen projekt i c) och filnamn (med filnamnet contacts.json)
    private readonly FileService _fileService = new(@"c:\projekt", "contacts.json");

    // Add lägger till en kontakt i listan och sparar listan till en fil.
    public void Add(Contact contact)
    {
        _contacts.Add(contact);
        _fileService.SaveListToFile(_contacts);
    }

    // GetAll hämtar alla kontakter från filen.
    public IEnumerable<Contact> GetAll()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }
}

