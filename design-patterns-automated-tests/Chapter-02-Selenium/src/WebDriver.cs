﻿using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Chapter_02_Selenium.src;

/// <summary>
/// Simple factory design pattern to create a WebDriver instance
/// </summary>
public class WebDriver : Driver
{
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;

    public override void Start(Browser browser)
    {
        switch (browser)
        {
            case Browser.Chrome:
                new DriverManager().SetUpDriver(new ChromeConfig());
                _webDriver = new ChromeDriver();
                break;
            case Browser.Firefox:
                new DriverManager().SetUpDriver(new FirefoxConfig());
                _webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                break;
            case Browser.Edge:
                new DriverManager().SetUpDriver(new EdgeConfig());
                _webDriver = new EdgeDriver(Environment.CurrentDirectory);
                break;
            //case Browser.Safari:
            //    new DriverManager().SetUpDriver(new Safar());
            //    _webDriver = new SafariDriver(Environment.CurrentDirectory);
            //    break;
            case Browser.InternetExplorer:
                new DriverManager().SetUpDriver(new InternetExplorerConfig());
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
