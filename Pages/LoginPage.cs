using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercatorAutomationTest.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement userName_inputText => driver.FindElement(By.Id("user-name"));
        IWebElement password_inputText => driver.FindElement(By.Id("password"));
        IWebElement login_button => driver.FindElement(By.ClassName("btn_action"));



        public HomePage userLogin(string url, string username, string password)
        {
            driver.Url = url;
            userName_inputText.SendKeys(username);
            password_inputText.SendKeys(password);
            login_button.Click();
            return new HomePage(driver);
        }
    }
}
