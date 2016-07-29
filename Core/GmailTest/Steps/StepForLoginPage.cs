using OpenQA.Selenium;
using Core.Driver;
using System;
using OpenQA.Selenium.Support.UI;
using WebDriverLibrary.Pages;
using Core.Page;

namespace WebDriver.Steps
{
    public class StepForLoginPage : AbstractPage
    {

        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.GetDriver();
        }

        public void CloseBrowser()
        {
            Driver.CloseBrowser();
        }

        public override void OpenStartPage()
        {
            LoginPage loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl(loginPage.URL);
        }

        public void LoginGmail(string userEmail, string password)
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.tInputEmailField.SetText(userEmail);
            loginPage.bNext.Click();
            loginPage.tinputPasswordField.SetText(password);
            loginPage.bEnter.Click();
        }

        public void LoginGmail(string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.bFirstUser.Click();
            loginPage.tinputPasswordField.SetText(password);
            loginPage.bEnter.Click();
        }

        public void LoginGmail2(string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.bSecondUser.Click();
            loginPage.tinputPasswordField.SetText(password);
            loginPage.bEnter.Click();
        }

        
    }
}
