namespace Principles.LiskovSubstitution;
public class GoldDiscountCalculator : DiscountCalculator, IBonusPointsDiscountCalculator
{
    public override double CalculateRegularDiscount(double totalPrice)
    {
        return base.CalculateRegularDiscount(totalPrice) - 50;
    }

    public override double CalculateBonusPointsDiscount(double totalPrice, int points)
    {
        return totalPrice - points * 1;
    }
}