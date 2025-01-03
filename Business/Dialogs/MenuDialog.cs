using Business.Services;

namespace Business.Dialogs;

public class MenuDialog(MenuService menuService)
{
    private readonly MenuService _menuService = menuService;

    // Visar en dialog för att välja alternativ
    public void MenuOptionsDialog()
    {
        // Loopar tills användaren väljer att avsluta applikationen när menyn visas. Jag har inte fixat en avslutning utanför menyn som exempel under skapandet av kontakt.
        while (true)
        {
            Console.WriteLine("1. Visa kontakter.");
            Console.WriteLine("2. Skapa en ny kontakt.");
            Console.WriteLine("3. För att avsluta applikationen.");
            Console.Write("\nVar vänlig och välj ett alternativ: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                // Visar alla kontakter
                case "1":
                    Console.WriteLine("\n---> Visar kontakter \n");
                    _menuService.ViewAllContactsDialog();
                    break;
                // Skapa en ny kontakt
                case "2":
                    Console.WriteLine("\n---> Skapa en ny kontakt \n");
                    _menuService.CreateContactDialog();
                    break;
                // Avsluta applikationen
                case "3":
                    Console.WriteLine("\nHej då!");
                    Environment.Exit(-1);
                    return;
                // Rensar konsolfönstret - underlättar för användaren
                case "clr":
                    Console.Clear();
                    break;
                // Ogiltig inmatning - Försök igen
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning! Försök igen.\n");
                    break;
            }
        }
    }
}
