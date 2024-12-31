using OpenQA.Selenium;

namespace Chapter_02_Selenium.src;
public abstract class Driver
{
    public abstract void Start(Browser browser);
    public abstract void Quit();
    public abstract void GoToUrl(string url);
    public abstract Element FindElement(By bylocator);
    public abstract List<Element> FindElements(By locator);
}
