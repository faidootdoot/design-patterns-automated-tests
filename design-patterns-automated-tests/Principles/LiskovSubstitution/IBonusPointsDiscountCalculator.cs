namespace Principles.LiskovSubstitution;
public interface IBonusPointsDiscountCalculator
{
    double CalculateBonusPointsDiscount(double totalPrice, int points);
}
