using Chapter_02_Selenium.src;

namespace Chapter_02_Selenium.Test;

public class Tests
{
    private static Driver _driver;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _driver = new LoggingDriver(new WebDriver());
        _driver.Start(Browser.Chrome);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    private void Login (string userName)
    {

    }
}
