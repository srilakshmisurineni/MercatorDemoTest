using MercatorAutomationTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MercatorAutomationTest.Steps
{
    [Binding]
    public class BaseSteps
    {
        private IWebDriver driver;
        private decimal maxItemPrice;
        private string? maxItemName;
        public BaseSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        LoginPage loginPage;
        HomePage homePage;
        ProductDetails productDetails;
        ShoppingCart shoppingCart;

        [Given(@"I am logged in as a standard user")]
        public void GivenIAmLoggedInAsAStandardUser()
        {
            loginPage = new LoginPage(driver);
            loginPage.userLogin("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            Thread.Sleep(5000);
        }
        [Given(@"I am on home page")]
        public void GivenIAmOnHomePage()
        {
            homePage = new HomePage(driver);
            Assert.IsTrue(homePage.getPageTitle() == "Products");
        }

        [Given(@"I select an item with max price on the page")]
        public void GivenISelectAnItemWithMaxPriceOnThePage()
        {
            homePage = new HomePage(driver);
            var maxItemDetailsInHomePage = homePage.getMaxPriceItem();
            maxItemName = maxItemDetailsInHomePage.Item1;
            maxItemPrice = maxItemDetailsInHomePage.Item2;
        }

        [When(@"I click Add to cart")]
        public void WhenIClickAddToCart()
        {
            productDetails = new ProductDetails(driver);
            var maxItemDetailsInProductDetails = productDetails.addMaxItemToCart();
            string maxItemName_chekcInProductDetails = maxItemDetailsInProductDetails.Item1;
            decimal maxItemPrice_chekcInProductDetails = maxItemDetailsInProductDetails.Item2;
            string getShoppingCartCount = maxItemDetailsInProductDetails.Item3;

            Assert.IsTrue(maxItemName == maxItemName_chekcInProductDetails);
            Assert.IsTrue(maxItemPrice == maxItemPrice_chekcInProductDetails);
            Assert.IsTrue(getShoppingCartCount == "1");
            Thread.Sleep(5000);

        }

        [Then(@"I see the selected product in basket")]
        public void ThenISeeTheSelectedProductInBasket()
        {
            shoppingCart = new ShoppingCart(driver);
            var maxItemDetailsInCart = shoppingCart.getItemDetailsFromCart();
            string maxItemName_chekcInCart = maxItemDetailsInCart.Item1;
            decimal maxItemPrice_chekcInCart = maxItemDetailsInCart.Item2;

            Assert.IsTrue(maxItemName == maxItemName_chekcInCart);
            Assert.AreEqual(maxItemPrice, maxItemPrice_chekcInCart);
        }
    }
}
