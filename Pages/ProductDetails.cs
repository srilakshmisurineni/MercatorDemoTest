using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MercatorAutomationTest.Pages
{
    public class ProductDetails
    {
        private IWebDriver driver;
        public ProductDetails(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement getItemName => driver.FindElement(By.XPath("//div[contains(@class, 'inventory_details_name')]"));
        IWebElement getItemPrice => driver.FindElement(By.XPath("//div[contains(@class, 'inventory_details_price')]"));
        IWebElement addToCartButton => driver.FindElement(By.XPath("//button[contains(text(),'Add to cart')]"));
        IWebElement shoppingCartLink => driver.FindElement(By.ClassName("shopping_cart_link"));

        public (string, decimal, string, ShoppingCart) addMaxItemToCart()
        {
            string maxItemName_chekcInProductDetails = getItemName.Text;
            decimal maxItemPrice_chekcInProductDetails = decimal.Parse(Regex.Replace(getItemPrice.Text, "[^0-9.]", ""));
            addToCartButton.Click();
            string getShoppingCartCount = shoppingCartLink.Text;
            shoppingCartLink.Click();
            return (maxItemName_chekcInProductDetails, maxItemPrice_chekcInProductDetails, getShoppingCartCount, (new ShoppingCart(driver)));
        }
    }
}
