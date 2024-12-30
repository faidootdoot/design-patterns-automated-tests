namespace Principles.LiskovSubstitution;

public class DiscountCalculator
{

    public virtual double CalculateRegularDiscount(double totalPrice)
    {
        return totalPrice;
    }

    public virtual double CalculateBonusPointsDiscount(double totalPrice, int points)
    {
        return totalPrice - points * 0.1;
    }
}
