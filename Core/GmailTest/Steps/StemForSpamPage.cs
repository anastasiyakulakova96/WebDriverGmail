using Core;
using Core.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverLibrary.Pages;

namespace WebDriverLibrary.Steps
{
    public class StemForSpamPage
    {
        IWebDriver driver;
        SpamPage spamPage;

        public StemForSpamPage(IWebDriver driver)
        {
            this.driver = driver;
            spamPage = new SpamPage(driver);
        }

        public void GoToSpam(string spamFolder)
        {
            //SpamPage spamPage = new SpamPage(driver);
            spamPage.tInputField.SetText(spamFolder);
            spamPage.bSearchSpamFolder.Click();
        }

        public bool AssertSpam(string userEMail)
        {
           // SpamPage spamPage = new SpamPage(driver);
            return spamPage.FindSpamSender().Equals(userEMail);
        }
        public void MarkLetterNotSpam()
        {
           // SpamPage spamPage = new SpamPage(driver);
            Waiter.WaitElement();
            IWebElement element = driver.FindElement(By.XPath(spamPage.firstCheckBox));
            spamPage.cFirstCheckBox.Click();
            spamPage.bNotASpam.Click();
        }

        public void OpenLetterAndMarkNotSpam()
        {
           // SpamPage spamPage = new SpamPage(driver);
            Waiter.WaitElement();
            spamPage.bFirstMessage.Click();
            spamPage.bOK.Click();
        }
    }
}
