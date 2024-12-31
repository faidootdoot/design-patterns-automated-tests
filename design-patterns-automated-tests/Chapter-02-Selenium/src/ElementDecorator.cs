using OpenQA.Selenium;

namespace Chapter_02_Selenium.src;

/// <summary>
/// Abstratct class ElementDecorator that inherits from Element
/// This is providing the implementation of Element
/// This is not concrete
/// </summary>
public abstract class ElementDecorator(Element element) : Element
{
    protected readonly Element Element = element;

    public override By By => Element.By;
    public override string Text => Element.Text;
    public override bool? Enabled => Element.Enabled;
    public override bool? Displayed => Element.Displayed;
    public override void Click() => Element.Click();
    public override string GetDomAttribute(string attributeName) => Element.GetDomAttribute(attributeName);
    public override void TypeText(string text) => Element.TypeText(text);
}
