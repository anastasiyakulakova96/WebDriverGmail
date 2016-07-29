using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverLibrary.Pages;
using Core.Driver;
using OpenQA.Selenium;
using AutoItX3Lib;
using System.Threading;

namespace WebDriverLibrary.Steps
{
   public class StepForMainPage
    {
        IWebDriver driver;
        private const string SETTINGPAGE = "fwdandpop";
        public string path= @"D:\Books.xml";



        public void InitBrowser()
        {
            driver = Driver.GetDriver();
        }

        public void CloseBrowser()
        {
            Driver.CloseBrowser();
        }

        public void WriteALetter(string addressee)
        {
         MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("hi");
            mainPage.tLetter.SetText("hello");
            mainPage.bSend.Click();
        }

        public void WriteALetterWithAttach(string addressee)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("hi");
            mainPage.bAttachFile.Click();
            //mainPage.bSend.Click();
            IAutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            autoIT.Send(path);
            Thread.Sleep(7000);
            autoIT.Send("{ENTER}");
           // Thread.Sleep(7000);
            mainPage.bSend.Click();
        }

        public void LogOut()
        {
         MainPage mainPage = new MainPage(driver);
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
            mainPage.bOtherAccount.Click();
            mainPage.bAddOneMoreAccount.Click();
        }

        public void LogOut222()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
            mainPage.bAddAccount.Click();
          //  mainPage.bAddOneMoreAccount.Click();
        }

        public void LogOut2()
        {
          MainPage mainPage = new MainPage(driver);
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();

        }

        public void MarkTheLetter()
        {
         MainPage mainPage = new MainPage(driver);
            mainPage.cFirstCheckBox.Click();
            mainPage.bMark.Click();
        }

        public void OpenSettings()
        {
           MainPage mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(mainPage.URL + SETTINGPAGE);
        }

        public void OpenMessage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bFirstMessage.Click();
            mainPage.lForward.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            mainPage.confirmButtonInNewTab.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.First());

        }

    }
}
