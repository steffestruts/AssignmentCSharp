using Business.Models;
using Business.Services;
namespace Business.Dialogs;

public class MenuDialog(MenuService menuService)
{
    private readonly MenuService _menuService = menuService;

    public void MenuOptionsDialog()
    {
        while (true)
        {
            Console.WriteLine("1. Visa kontakter");
            Console.WriteLine("2. Skapa en ny kontakt");
            Console.WriteLine("3. För att avsluta applikationen");
            var option = Dialogs.Prompt("\nVar vänlig och välj ett alternativ: ");
            switch (option)
            {
                // View all contacts
                case "1":
                    Console.Clear();
                    Console.WriteLine("---> Visar kontakter <--- \n");
                    Console.WriteLine("******************************************************** \n");
                    _menuService.ViewAllContactsDialog();
                    break;
                // Create a new contact
                case "2":
                    Console.Clear();
                    Console.WriteLine("---> Skapa en ny kontakt <--- \n");
                    _menuService.CreateContactDialog();
                    break;
                // Quit the console application
                case "3":
                    Console.WriteLine("\nHej då!");
                    Environment.Exit(-1);
                    return;
                // Clear the console
                case "clr":
                    Console.Clear();
                    break;
                // Invalid input - Try again message
                default:
                    Console.WriteLine("\n----------------------------------------------");
                    Console.WriteLine("\nOgiltig inmatning! Försök igen.\n");
                    break;
            }
        }
    }
}
