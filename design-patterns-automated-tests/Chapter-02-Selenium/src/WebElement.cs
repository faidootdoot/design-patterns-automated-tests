using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Chapter_02_Selenium.src;
public class WebElement(IWebDriver webDriver, IWebElement webElement, By by) : Element
{
    // Set using the primary constructor that is CSharp 12 feature
    private readonly IWebDriver _webDriver = webDriver;
    private readonly IWebElement _webElement = webElement;
    private readonly By _by = by;

    public override By By => _by;

    public override string Text => _webElement?.Text!;

    public override bool? Enabled => _webElement?.Enabled;

    public override bool? Displayed => _webElement?.Displayed;

    public override void Click()
    {
        WaitToBeClickable(By);
        _webElement?.Click();
    }

    public override string GetDomAttribute(string attributeName) =>  _webElement?.GetDomAttribute(attributeName)!;
    
    public override void TypeText(string text)
    {
        _webElement?.Clear();
        _webElement?.SendKeys(text);
    }

    private void WaitToBeClickable(By by)
    {
        WebDriverWait webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
    }
}
