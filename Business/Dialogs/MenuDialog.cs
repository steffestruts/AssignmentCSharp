using Business.Models;
using Business.Services;
namespace Business.Dialogs;

public class MenuDialog(MenuService menuService)
{
    private readonly MenuService _menuService = menuService;

    // Visar en dialog för att välja alternativ
    public void MenuOptionsDialog()
    {
        // Loopa tills användaren väljer att avsluta applikationen
        while (true)
        {
            Console.WriteLine("1. Visa kontakter");
            Console.WriteLine("2. Skapa en ny kontakt");
            Console.WriteLine("3. För att avsluta applikationen");
            var option = Dialogs.Prompt("\nVar vänlig och välj ett alternativ: ");
            switch (option)
            {
                // Visar alla kontakter
                case "1":
                    Console.Clear();
                    Console.WriteLine("---> Visar kontakter \n");
                    _menuService.ViewAllContactsDialog();
                    break;
                // Skapa en ny kontakt
                case "2":
                    Console.Clear();
                    Console.WriteLine("---> Skapa en ny kontakt \n");
                    _menuService.CreateContactDialog();
                    break;
                // Avsluta applikationen
                case "3":
                    Console.WriteLine("\nHej då!");
                    Environment.Exit(-1);
                    return;
                // Rensa konsolfönstret
                case "clr":
                    Console.Clear();
                    break;
                // Ogiltig inmatning - Försök igen
                default:
                    Console.WriteLine("\n----------------------------------------------");
                    Console.WriteLine("\nOgiltig inmatning! Försök igen.\n");
                    break;
            }
        }
    }
}
