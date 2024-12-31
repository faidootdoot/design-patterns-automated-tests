using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Chapter_02_Selenium.src;
public class WebElement : Element
{
    private readonly IWebDriver _webDriver;
    private readonly IWebElement _webElement;
    private readonly By _by;

    public WebElement(IWebDriver webDriver, IWebElement webElement, By by) => (_webDriver, _webElement, _by) = (webDriver, webElement, by);

    public override By By => _by;

    public override string Text => _webElement?.Text!;

    public override bool? Enabled => _webElement?.Enabled;

    public override bool? Displayed => _webElement?.Displayed;

    public override void Click()
    {
        WaitToBeClickable(By);
        _webElement?.Click();
    }

    public override string GetAttribute(string attributeName) =>  _webElement?.GetDomAttribute(attributeName)!;
    
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
