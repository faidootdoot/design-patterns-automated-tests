namespace Principles.OpenClosed;

public class DiscountCalculator
{
    /// <summary>
    /// Calculate discount based on order type.
    /// This will need to change every time a new order type is added.
    /// This does not follow open/closed principle.
    /// </summary>
    /// <param name="orderType"></param>
    /// <param name="totalPrice"></param>
    /// <returns></returns>
    public static double CalculateDiscount(OrderType orderType, double totalPrice)
    {
        if (orderType == OrderType.Normal)
        {
            return totalPrice;
        }
        else if (orderType == OrderType.Silver)
        {
            return totalPrice - 20;
        }
        else if (orderType == OrderType.Gold)
        {
            return totalPrice - 50;
        }
        else
        {
            return totalPrice;
        }
    }

    /// <summary>
    /// Calculate discount based on order type.
    /// </summary>
    /// <param name="totalPrice"></param>
    /// <returns></returns>
    public virtual double CalculateDiscount(double totalPrice)
    {
        return totalPrice;
    }
}

/// <summary>
/// Silver discount calculator.
/// </summary>
public class SilverDiscountCalculator : DiscountCalculator
{
    public override double CalculateDiscount(double totalPrice)
    {
        return totalPrice - 20;
    }
}

/// <summary>
/// Gold discount calculator.
/// </summary>
public class GoldDiscountCalculator : DiscountCalculator
{
    public override double CalculateDiscount(double totalPrice)
    {
        return totalPrice - 50;
    }
}