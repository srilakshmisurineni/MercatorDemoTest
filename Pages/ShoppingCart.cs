using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MercatorAutomationTest.Pages
{
    public class ShoppingCart
    {
        private IWebDriver driver;
        public ShoppingCart(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement getItemName => driver.FindElement(By.ClassName("inventory_item_name"));
        IWebElement getItemPrice => driver.FindElement(By.ClassName("inventory_item_price"));

        public (string, decimal) getItemDetailsFromCart()
        {
            string maxItemName_chekcInCart = getItemName.Text;
            decimal maxItemPrice_chekcInCart = decimal.Parse(Regex.Replace(getItemPrice.Text, "[^0-9.]", ""));
            return (maxItemName_chekcInCart, maxItemPrice_chekcInCart);
        }
    }
}
