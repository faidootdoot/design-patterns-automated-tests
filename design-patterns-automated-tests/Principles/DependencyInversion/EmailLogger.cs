namespace Principles.DependencyInversion;
public class EmailLogger : ILogger
{
    public void CreateLogEntry(string errorMessage)
    {
        EmailFactory.SendEmail(errorMessage);
    }
}
