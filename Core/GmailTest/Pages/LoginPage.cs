using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Core.Page;
using Core;
using Core.Elements;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriver
{
    public class LoginPage
    {
        private string BASE_URL = "https://mail.google.com/";
        public string URL { get { return BASE_URL; } set { BASE_URL = value; } }
        public Button bNext { get; set; }
        public Button bEnter { get; set; }
        public Button bFirstUser { get; set; }
        public Button bSecondUser { get; set; }
        public TextBox tInputEmailField { get; set; }
        public TextBox tinputPasswordField { get; set; }

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

            bNext = new Button(By.Id("next"), driver, "bNext");
            bEnter = new Button(By.Id("signIn"), driver, "bEnter");
            bFirstUser = new Button(By.XPath("//*[@id='choose-account-0']"), driver, "bFirstUser");
            bSecondUser = new Button(By.XPath("//*[@id='choose-account-1']"), driver, "bSecondUser");
            tInputEmailField = new TextBox(By.Id("Email"), driver, "tInputEmailField");
            tinputPasswordField = new TextBox(By.Id("Passwd"), driver, "tinputPasswordField");
        }
    }
}
