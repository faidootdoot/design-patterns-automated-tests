using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Chapter_02_Selenium.src;

public class WebDriver : Driver
{
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;

    public override void Start(Browser browser)
    {
        switch (browser)
        {
            case Browser.Chrome:
                _webDriver = new ChromeDriver(Environment.CurrentDirectory);
                break;
            case Browser.Firefox:
                _webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                break;
            case Browser.Edge:
                _webDriver = new EdgeDriver(Environment.CurrentDirectory);
                break;
            case Browser.Safari:
                _webDriver = new SafariDriver(Environment.CurrentDirectory);
                break;
            case Browser.InternetExplorer:
                _webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
                break;
            case Browser.NotSet:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
    }


    public override void Quit()
    {
        _webDriver.Quit();
    }

    public override void GoToUrl(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public override Element FindElement(By bylocator)
    {
        IWebElement nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementExists(bylocator));
        Element element = new WebElement(_webDriver, nativeWebElement, bylocator);
        Element logElement = new LogElement(element);
        return logElement;
    }

    public override List<Element> FindElements(By locator)
    {
        ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        List<Element> elements = [];
        foreach (IWebElement nativeWebElement in nativeWebElements)
        {
            Element element = new WebElement(_webDriver, nativeWebElement, locator);
            Element logElement = new LogElement(element);
            elements.Add(logElement);
        }
        return elements;
    }
}
