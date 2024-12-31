using OpenQA.Selenium;

namespace Chapter_02_Selenium.src;

public abstract class DriverDecorator(Driver driver) : Driver
{
    protected readonly Driver Driver = driver;

    public override void Start(Browser browser)
    {
        Driver?.Start(browser);
    }

    public override void Quit()
    {
        Driver?.Quit();
    }
    public override void GoToUrl(string url)
    {
        Driver?.GoToUrl(url);
    }

    public override Element FindElement(By bylocator)
    {
        return Driver?.FindElement(bylocator) ?? throw new InvalidOperationException("Driver is null");
    }

    public override List<Element> FindElements(By locator)
    {
        return Driver?.FindElements(locator) ?? [];
    }

}
