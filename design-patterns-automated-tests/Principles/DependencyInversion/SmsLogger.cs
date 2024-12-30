namespace Principles.DependencyInversion;
internal class SmsLogger : ILogger
{
    public void CreateLogEntry(string errorMessage)
    {
        SmsFactory.SendSms(errorMessage);
    }
}
