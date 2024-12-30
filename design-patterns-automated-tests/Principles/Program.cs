// See https://aka.ms/new-console-template for more information
using Principles;
using OpenClosed = Principles.OpenClosed;
using SingleResponsibility = Principles.SingleResponsibility;
using LiskovSubstitution = Principles.LiskovSubstitution;


Console.WriteLine("Single Responsibility principle SRP");
Console.WriteLine("===================================");


Console.WriteLine("Create a customer order, if fail then there is a dedicated file logger to log error to file");
SingleResponsibility.CustomerOrder customerOrder = new();
customerOrder.Create();


Console.WriteLine();
Console.WriteLine("Open/Closed Principle");
Console.WriteLine("=====================");

Console.WriteLine("Using discount calculator to calculate discount based on order type - not open/closed principle");
Console.WriteLine($"{OpenClosed.DiscountCalculator.CalculateDiscount(OrderType.Silver, 100)}");

Console.WriteLine("Using silver discount calculator to calculate discount based - open/closed principle");
Console.WriteLine($"{new OpenClosed.SilverDiscountCalculator().CalculateDiscount(100)}");

Console.WriteLine("Using gold discount calculator to calculate discount based - open/closed principle");
Console.WriteLine($"{new OpenClosed.GoldDiscountCalculator().CalculateDiscount(100)}");

Console.WriteLine();
Console.WriteLine("Liskov Principle");
Console.WriteLine("================");


Console.WriteLine("Discount calculators list will generate error as CalculateBonusPointsDiscount throws error for platinum");

List<LiskovSubstitution.DiscountCalculator> _discountCalculators =
[
    new LiskovSubstitution.SilverDiscountCalculator(),
    new LiskovSubstitution.GoldDiscountCalculator(),
    new LiskovSubstitution.PlatinumDiscountCalculator()
];

Console.WriteLine("Regular discount");
foreach (var discountCalculator in _discountCalculators)
{
    Console.WriteLine(discountCalculator.CalculateRegularDiscount(1250));
}

Console.WriteLine("Bonus point discount");
try
{
    foreach (var discountCalculator in _discountCalculators)
    {
        Console.WriteLine(discountCalculator.CalculateBonusPointsDiscount(1250, 100));
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("Platinum discount calcuator does not implement IBonusPointsDiscountCalculator, so cannot added to the list so will avoid the fail");
Console.WriteLine("Bonus point discount");
List<LiskovSubstitution.IBonusPointsDiscountCalculator> _bonusDiscountCalculators =
[
    new LiskovSubstitution.SilverDiscountCalculator(),
    new LiskovSubstitution.GoldDiscountCalculator()
];

foreach (LiskovSubstitution.IBonusPointsDiscountCalculator discountCalculator in _bonusDiscountCalculators)
{
    Console.WriteLine(discountCalculator.CalculateBonusPointsDiscount(1250, 100));
}