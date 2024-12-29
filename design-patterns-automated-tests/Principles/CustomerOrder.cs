namespace Principles;
public class CustomerOrder
{

    private readonly FileLogger fileLogger = new FileLogger();

    public void Create()
    {
        try {
            // Create a customer order.
            throw new Exception("Unable to create customer order.");
        }
        catch (Exception ex)
        {
            FileLogger.CreateLogEntry(ex.Message);
        }
    }
}
