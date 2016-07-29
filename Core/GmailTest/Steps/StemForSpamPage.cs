﻿using Core;
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

        public void InitBrowser()
        {
            driver = Driver.GetDriver();
        }

        public void CloseBrowser()
        {
            Driver.CloseBrowser();
        }
        public void GoToSpam(string spamFolder)
        {
            SpamPage spamPage = new SpamPage(driver);
            spamPage.tInputField.SetText(spamFolder);
            spamPage.bSearchSpamFolder.Click();
        }

        public bool AssertSpam(string userEMail)
        {
            SpamPage spamPage = new SpamPage(driver);
            return spamPage.FindSpamSender().Equals(userEMail);
        }

        //public void NotASpam()
        //{
        //    SpamPage spamPage = new SpamPage(driver);
        //    spamPage.RemoveMessageToSpam();
        //}
    }
}
