// See https://aka.ms/new-console-template for more information
using Principles;


Console.WriteLine("Single Responsibility principle SRP");
Console.WriteLine("===================================");


Console.WriteLine("Create a customer order, if fail then there is a dedicated file logger to log error to file");
CustomerOrder customerOrder = new();
customerOrder.Create();


Console.WriteLine();
Console.WriteLine("Open/Closed Principle");
Console.WriteLine("=====================");

Console.WriteLine("Using discount calculator to calculate discount based on order type - not open/closed principle");
Console.WriteLine($"{DiscountCalculator.CalculateDiscount(OrderType.Silver, 100)}");

Console.WriteLine("Using silver discount calculator to calculate discount based - open/closed principle");
Console.WriteLine($"{new SilverDiscountCalculator().CalculateDiscount(100)}");

Console.WriteLine("Using gold discount calculator to calculate discount based - open/closed principle");
Console.WriteLine($"{new GoldDiscountCalculator().CalculateDiscount(100)}");

Console.WriteLine();
Console.WriteLine("Liskov Principle");
Console.WriteLine("================");

