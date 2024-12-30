namespace Principles.DependencyInversion;
public class PlatinumCustomerOrder : CustomerOrder
{
    public PlatinumCustomerOrder() : base(new SmsLogger())
    {
    }
}