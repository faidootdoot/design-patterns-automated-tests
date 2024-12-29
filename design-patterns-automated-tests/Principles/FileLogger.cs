namespace Principles;

public class FileLogger
{
    public static void CreateLogEntry(string message)
    {
        // Log the message to a file.
        File.WriteAllText("log.txt", message);
    }
}
