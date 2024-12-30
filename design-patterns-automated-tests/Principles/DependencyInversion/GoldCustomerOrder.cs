namespace Principles.DependencyInversion;
internal class GoldCustomerOrder : CustomerOrder
{
    public GoldCustomerOrder() : base(new EmailLogger())
    {
    }
}
