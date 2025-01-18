using System.Diagnostics;
using Chapter_03_Classic_Observer_Pattern.src;
using Chapter_03_Speed.src;
using OpenQA.Selenium;

namespace Chapter_03_Speed.Test;

public class Tests
{
    private static Driver _driver;
    private static Stopwatch _stopwatch;
    private static string _purchaseEmail = default!;
    private static string _purchaseOrderNumber = default!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _stopwatch = Stopwatch.StartNew();
        _driver = new LoggingDriver(new WebCoreDriver());
        _driver.Start(Browser.Chrome);

        Debug.WriteLine($"Browser initialisation duration: {_stopwatch.Elapsed.TotalSeconds}");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
        _stopwatch.Stop();
    }

    [Test]
    public void CompletePurchaseSuccessfully_WhenNewClient()
    {
        AddRocketToShoppingCart();
        ApplyCoupon();
        IncreaseProductQuantity();
        var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        proceedToCheckout.Click();
        _driver.WaitUntilPageLoadsCompletely();
        var billingFirstName = _driver.FindElement(By.Id("billing_first_name"));
        billingFirstName.TypeText("Anton");
        var billingLastName = _driver.FindElement(By.Id("billing_last_name"));
        billingLastName.TypeText("Angelov");
        var billingCompany = _driver.FindElement(By.Id("billing_company"));
        billingCompany.TypeText("Space Flowers");
        var billingCountryWrapper = _driver.FindElement(By.Id("select2-billing_country-container"));
        billingCountryWrapper.Click();
        var billingCountryFilter = _driver.FindElement(By.ClassName("select2-search__field"));
        billingCountryFilter.TypeText("Germany");
        var germanyOption = _driver.FindElement(By.XPath("//*[contains(text(),'Germany')]"));
        germanyOption.Click();
        var billingAddress1 = _driver.FindElement(By.Id("billing_address_1"));
        billingAddress1.TypeText("1 Willi Brandt Avenue Tiergarten");
        var billingAddress2 = _driver.FindElement(By.Id("billing_address_2"));
        billingAddress2.TypeText("Lützowplatz 17");
        var billingCity = _driver.FindElement(By.Id("billing_city"));
        billingCity.TypeText("Berlin");
        var billingZip = _driver.FindElement(By.Id("billing_postcode"));
        billingZip.TypeText("10115");
        var billingPhone = _driver.FindElement(By.Id("billing_phone"));
        billingPhone.TypeText("+00498888999281");
        var billingEmail = _driver.FindElement(By.Id("billing_email"));
        billingEmail.TypeText(GenerateUniqueEmail());
        _purchaseEmail = GenerateUniqueEmail();
        _driver.WaitForAjax();
        var placeOrderButton = _driver.FindElement(By.Id("place_order"));
        placeOrderButton.Click();
        _driver.WaitForAjax();
        var receivedMessage = _driver.FindElement(By.XPath("//h1[text() = 'Order received']"));

        Assert.That(receivedMessage.Text, Is.EqualTo("Order received"));
    }

    [Test]
    public void CompletePurchaseSuccessfully_WhenExistingClient()
    {
        AddRocketToShoppingCart();
        ApplyCoupon();
        IncreaseProductQuantity();
        var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        proceedToCheckout.Click();
        _driver.WaitUntilPageLoadsCompletely();
        var loginHereLink = _driver.FindElement(By.LinkText("Click here to login"));
        loginHereLink.Click();
        Login("info@berlinspaceflowers.com");
        _driver.WaitForAjax();
        var placeOrderButton = _driver.FindElement(By.Id("place_order"));
        placeOrderButton.Click();
        _driver.WaitForAjax();
        var receivedMessage = _driver.FindElement(By.XPath("//h1[text() = 'Order received']"));

        Assert.That(receivedMessage.Text, Is.EqualTo("Order received"));

        var orderNumber = _driver.FindElement(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
        _purchaseOrderNumber = orderNumber.Text;

    }

    private static void Login(string userName)
    {
        _driver.WaitForAjax();
        var userNameTextField = _driver.FindElement(By.Id("username"));
        userNameTextField.TypeText(userName);
        var passwordField = _driver.FindElement(By.Id("password"));
        passwordField.TypeText(GetUserPasswordFromDb(userName));
        var loginButton = _driver.FindElement(By.XPath("//button[@name='login']"));
        loginButton.Click();
    }

    private static void IncreaseProductQuantity()
    {
        var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        quantityBox.TypeText("2");
        _driver.WaitForAjax();
        var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
        updateCart.Click();
        _driver.WaitForAjax();
        var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));

        Assert.That(totalSpan.Text, Is.EqualTo("114.00€"));
    }

    private static void ApplyCoupon()
    {
        var couponCodeTextField = _driver.FindElement(By.Id("coupon_code"));
        couponCodeTextField.TypeText("happybirthday");
        var applyCouponButton = _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        applyCouponButton.Click();
        _driver.WaitForAjax();
        var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));

        Assert.That(messageAlert.Text, Is.EqualTo("Coupon code applied successfully."));
    }

    private static void AddRocketToShoppingCart()
    {
        _driver.GoToUrl("http://demos.bellatrix.solutions/");

        var addToCartFalcon9 = _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        addToCartFalcon9.Click();
        _driver.WaitForAjax();
        var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
        viewCartButton.Click();
    }

    private static string GetUserPasswordFromDb(string userName)
    {
        return "@purISQzt%%DYBnLCIhaoG6$";
    }

    private static string GenerateUniqueEmail()
    {
        return $"{Guid.NewGuid()}@berlinspaceflowers.com";
    }
}
