namespace Principles.DependencyInversion;
public class FileLogger : ILogger
{
    public void CreateLogEntry(string errorMessage)
    {
        File.WriteAllText("log.txt", errorMessage);
    }
}
