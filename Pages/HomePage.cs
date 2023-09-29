using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MercatorAutomationTest.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // By pageTitle = By.CssSelector("div.header_secondary_container>span.title");
        IWebElement pageTitle => driver.FindElement(By.CssSelector("div.header_secondary_container>span.title"));
        public string getPageTitle()
        {
            return pageTitle.Text;
        }
        IList<IWebElement> listOfAllItemPrices => driver.FindElements(By.ClassName("inventory_item_price"));
        IList<IWebElement> maxItem => driver.FindElements(By.XPath("//div[@class='inventory_item_name']"));
        public (string, decimal, ProductDetails) getMaxPriceItem()
        {
            decimal[] allPrices = new Decimal[listOfAllItemPrices.Count];

            int i = 0;

            foreach (IWebElement element in listOfAllItemPrices)
            {
                allPrices[i++] = decimal.Parse(Regex.Replace(element.Text, "[^0-9.]", ""));
            }

            decimal maxItemPrice = allPrices.Max();
            int indexOfMaxPriceItem = allPrices.ToList().IndexOf(maxItemPrice);

            string maxItemName = maxItem[indexOfMaxPriceItem].Text;
            maxItem[indexOfMaxPriceItem].Click();
            return (maxItemName, maxItemPrice, (new ProductDetails(driver)));
        }
    }
}
