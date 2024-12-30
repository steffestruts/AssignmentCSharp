namespace Business.Dialogs;

public class Dialogs
{
    public static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine()!;
    }
}
