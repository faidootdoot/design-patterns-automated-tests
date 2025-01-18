using OpenQA.Selenium;

namespace Chapter_03_Classic_Observer_Pattern.src;
public abstract class Driver
{
    public abstract void Start(Browser browser);
    public abstract void Quit();
    public abstract void GoToUrl(string url);
    public abstract Element FindElement(By bylocator);
    public abstract List<Element> FindElements(By locator);
    public abstract void WaitForAjax();
    public abstract void WaitUntilPageLoadsCompletely();
}
