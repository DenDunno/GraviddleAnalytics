
public class Logger
{
    public void LogSuccess(string successMessage)
    {
        Log(successMessage, ConsoleColor.Green);
    }
    
    public void LogError(string errorMessage)
    {
        Log(errorMessage, ConsoleColor.Red);
    }
    
    public void Log(string text)
    {
        Log(text, ConsoleColor.Yellow);
    }

    private void Log(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }
}