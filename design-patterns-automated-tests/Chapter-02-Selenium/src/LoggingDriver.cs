using OpenQA.Selenium;

namespace Chapter_02_Selenium.src;
public class LoggingDriver(Driver driver) : DriverDecorator(driver)
{
    public override void Start(Browser browser)
    {
        Console.WriteLine($"Starting browser: {browser}");
        base.Start(browser);
    }

    public override void Quit()
    {
        Console.WriteLine("Quitting browser");
        base.Quit();
    }

    public override void GoToUrl(string url)
    {
        Console.WriteLine($"Navigating to: {url}");
        base.GoToUrl(url);
    }

    public override Element FindElement(By bylocator)
    {
        Console.WriteLine($"Finding element: {bylocator}");
        return base.FindElement(bylocator);
    }

    public override List<Element> FindElements(By locator)
    {
        Console.WriteLine($"Finding elements: {locator}");
        return base.FindElements(locator);
    }
}
