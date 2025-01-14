using System.Diagnostics;
using Chapter_02_Selenium.src;

namespace Chapter_02_Selenium.Test;

public class Tests
{
    private static Driver _driver;
    private static Stopwatch _stopwatch;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _stopwatch = Stopwatch.StartNew();
        _driver = new LoggingDriver(new WebDriver());
        _driver.Start(Browser.Chrome);

        Debug.WriteLine($"Browser initialisation duration: {_stopwatch.Elapsed.TotalSeconds}");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
        _stopwatch.Stop();
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
