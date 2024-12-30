namespace Business.Dialogs;

public class Dialogs
{
    // En metod som prompt-dialog för inmatning i konsolen
    public static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine()!;
    }
}
