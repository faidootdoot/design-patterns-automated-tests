using Chapter_03_Classic_Observer_Pattern.src;
using OpenQA.Selenium;

namespace Chapter_03_Speed.src;
public class LogElement(Element element) : ElementDecorator(element)
{
    public override By By => Element.By;

    public override string Text
    {
        get
        {
            Console.WriteLine($"Element Text = {Element?.Text}");
            return Element?.Text ?? string.Empty;
        }
    }

    public override bool? Enabled
    {
        get
        {
            Console.WriteLine($"Element Enabled = {Element?.Enabled}");
            return Element?.Enabled;
        }
    }

    public override bool? Displayed
    {
        get
        {
            Console.WriteLine($"Element Displayed = {Element?.Displayed}");
            return Element?.Displayed;
        }
    }

    public override void Click()
    {
        Console.WriteLine("Element Clicked");
        Element?.Click();
    }

    public override string GetDomAttribute(string attributeName)
    {
        Console.WriteLine($"Element GetDomAttribute = {Element?.GetDomAttribute(attributeName)}");
        return Element?.GetDomAttribute(attributeName) ?? string.Empty;
    }

    public override void TypeText(string text)
    {
        Console.WriteLine($"Element TypeText = {text}");
        Element?.TypeText(text);
    }
}
