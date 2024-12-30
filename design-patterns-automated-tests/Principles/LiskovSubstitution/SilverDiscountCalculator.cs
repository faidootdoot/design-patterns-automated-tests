namespace Principles.LiskovSubstitution;
public class SilverDiscountCalculator : DiscountCalculator, IBonusPointsDiscountCalculator
{
    public override double CalculateRegularDiscount(double totalPrice)
    {
        return base.CalculateRegularDiscount(totalPrice) - 20;
    }

    public override double CalculateBonusPointsDiscount(double totalPrice, int points)
    {
        return totalPrice - points * 0.5;
    }
}