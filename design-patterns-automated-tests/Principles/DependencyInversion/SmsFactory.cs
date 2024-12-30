
namespace Principles.DependencyInversion;
public class SmsFactory
{
    internal static void SendSms(string errorMessage)
    {
        Console.WriteLine($"Sending SMS: {errorMessage}");
    }
}
