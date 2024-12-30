using Business.Models;

namespace Business.Services;

public class MenuService
{
    private readonly ContactService _contactService = new();

    public void ViewAllContactsDialog()
    {
        // Fetching all users
        var contacts = _contactService.GetAll();

        // Loop with foreach and display users one by one
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Namn:",-15}{contact.FirstName} {contact.LastName}"); // Merging FirstName and LastName to a full name
            Console.WriteLine($"{"Adress:",-15}{contact.Address}");
            Console.WriteLine($"{"Postnummer:",-15}{contact.PostalCode}");
            Console.WriteLine($"{"Ort/stad:",-15}{contact.City}");
            Console.WriteLine($"{"E-postadress:",-15}{contact.Email}");
            Console.WriteLine($"{"Telefon:",-15}{contact.PhoneNumber}");
            Console.WriteLine($"{"Id:",-15}{contact.Id} \n");

            // Learning alignment in console, example code below: https://medium.com/@patelrajni31/how-to-do-alignment-within-string-format-in-c-9ebd001da344
            // Console.WriteLine("-------------------------------");
            // Console.WriteLine("First Name | Last Name  |   Age");
            // Console.WriteLine("-------------------------------");
            // Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Adam", "Gilchrist", 50));
            // Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Alena", "Parker", 55));
            // Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "John", "Roy", 40));
        }
        Console.WriteLine("******************************************************** \n");

    }

    public void CreateContactDialog()
    {
        Contact contact = new();

        // Input: FirstName or förnamn
        Console.Write("Skriv in förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        // Input: LastName or efternamn
        Console.Write("Skriv in efternamn: ");
        contact.LastName = Console.ReadLine()!;
        // Input: Email or e-postaddress
        Console.Write("Skriv in e-postaddress: ");
        contact.Email = Console.ReadLine()!;
        // Input: PhoneNumber or telefonnummer
        Console.Write("Skriv in telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!;
        // Input: Address or adress
        Console.Write("Skriv in adress: ");
        contact.Address = Console.ReadLine()!;
        // Input: PostalCode or postnummer
        Console.Write("Skriv in postnummer: ");
        contact.PostalCode = Console.ReadLine()!;
        // Input: City or stad/ort
        Console.Write("Skriv in stad/ort: ");
        contact.City = Console.ReadLine()!;
        Console.WriteLine(""); // Empty line for better readability

        // Adding inputs to list as single contact
        _contactService.Add(contact);
    }
}
