
namespace Principles.DependencyInversion;
public class EmailFactory
{
    internal static void SendEmail(string errorMessage)
    {
        Console.WriteLine($"Sending Email: {errorMessage}");
    }
}
