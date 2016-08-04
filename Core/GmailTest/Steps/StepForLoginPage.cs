using OpenQA.Selenium;
using Core.Driver;
using System;
using OpenQA.Selenium.Support.UI;
using WebDriverLibrary.Pages;
using Core.Page;
using WebDriverLibrary.Steps;

namespace WebDriver.Steps
{
    public class StepForLoginPage : AbstractPage
    {
        LoginPage loginPage;

        public StepForLoginPage(IWebDriver driver) : base(driver)
        {
            loginPage = new LoginPage(driver);
        }

        public override void OpenStartPage()
        {
            driver.Navigate().GoToUrl(loginPage.URL);
        }

        public void LoginGmail(string userEmail, string password)
        {
            loginPage.tInputEmailField.SetText(userEmail);
            loginPage.bNext.Click();
            loginPage.tinputPasswordField.SetText(password);
            loginPage.bEnter.Click();
        }

        public void LoginGmail(string password)
        {
            loginPage.bFirstUser.Click();
            loginPage.tinputPasswordField.SetText(password);
            loginPage.bEnter.Click();
        }

        public void LoginGmailAsSecondUser(string password)
        {
            loginPage.bSecondUser.Click();
            loginPage.tinputPasswordField.SetText(password);
            loginPage.bEnter.Click();
        }
    }
}
