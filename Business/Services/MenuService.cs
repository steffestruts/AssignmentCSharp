using Business.Models;

namespace Business.Services;

public class MenuService
{
    private readonly ContactService _contactService = new();

    public void ViewAllContactsDialog()
    {
        // Hämtar alla kontakter
        var contacts = _contactService.GetAll();

        // Loopa igenom alla kontakter och skriv ut dem, en efter en
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id:",-15}{contact.Id}");
            Console.WriteLine($"{"Namn:",-15}{contact.FirstName} {contact.LastName}"); // Flyttar ihop förnamn och efternamn för göra fullständigt namn
            Console.WriteLine($"{"Adress:",-15}{contact.Address}");
            Console.WriteLine($"{"Postnummer:",-15}{contact.PostalCode}");
            Console.WriteLine($"{"Ort/stad:",-15}{contact.City}");
            Console.WriteLine($"{"E-postadress:",-15}{contact.Email}");
            Console.WriteLine($"{"Telefon:",-15}{contact.PhoneNumber}\n");

            // Lär mig placering i konsolen, kodexempel nedan: https://medium.com/@patelrajni31/how-to-do-alignment-within-string-format-in-c-9ebd001da344
            // Console.WriteLine("-------------------------------");
            // Console.WriteLine("First Name | Last Name  |   Age");
            // Console.WriteLine("-------------------------------");
            // Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Adam", "Gilchrist", 50));
            // Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Alena", "Parker", 55));
            // Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "John", "Roy", 40));
        }
    }

    public void CreateContactDialog()
    {
        Contact contact = new();

        // Inmatning: FirstName or förnamn
        Console.Write("Skriv in förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        // Inmatning: LastName or efternamn
        Console.Write("Skriv in efternamn: ");
        contact.LastName = Console.ReadLine()!;
        // Inmatning: Email or e-postaddress
        Console.Write("Skriv in e-postaddress: ");
        contact.Email = Console.ReadLine()!;
        // Inmatning: PhoneNumber or telefonnummer
        Console.Write("Skriv in telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!;
        // Inmatning: Address or adress
        Console.Write("Skriv in adress: ");
        contact.Address = Console.ReadLine()!;
        // Inmatning: PostalCode or postnummer
        Console.Write("Skriv in postnummer: ");
        contact.PostalCode = Console.ReadLine()!;
        // Inmatning: City or stad/ort
        Console.Write("Skriv in stad/ort: ");
        contact.City = Console.ReadLine()!;
        // Tom rad för bättre läsbarhet
        Console.WriteLine(""); 

        // Lägger till en ny kontakt
        _contactService.Add(contact);
    }
}
