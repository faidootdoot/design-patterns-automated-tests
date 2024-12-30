namespace Principles.LiskovSubstitution;
public class PlatinumDiscountCalculator : DiscountCalculator
{
    public override double CalculateRegularDiscount(double totalPrice)
    {
        return base.CalculateRegularDiscount(totalPrice) - 100;
    }

    public override double CalculateBonusPointsDiscount(double totalPrice, int points)
    {
        throw new InvalidOperationException("Not applicable for Platinum orders.");
    }
}