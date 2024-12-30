namespace Principles.DependencyInversion;
public class CustomerOrder
{
    /// <summary>
    /// Create order by order type
    /// This goes against the single responsibility principle
    /// </summary>
    /// <param name="orderType"></param>
    public void Create(OrderType orderType)
    {
        try
        {
            /* Create order */
        }
        catch (Exception ex)
        {
            switch(orderType)
            {
                case OrderType.Platinum:
                    new SmsLogger().CreateLogEntry(ex.Message);
                    break;
                case OrderType.Gold:
                    new EmailLogger().CreateLogEntry(ex.Message);
                    break;
                default:
                    new FileLogger().CreateLogEntry(ex.Message);
                    break;
            }
        }
    }

    private ILogger _logger;

    public CustomerOrder(ILogger logger)
    {
        _logger = logger;
    }

    public void Create()
    {
        try
        {
            /* Create order */
            throw new Exception("Order creation failed");
        }
        catch (Exception ex)
        {
            _logger.CreateLogEntry(ex.Message);
        }
    }
}
