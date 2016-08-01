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
using OpenQA.Selenium.Support.UI;
using GmailTest;

namespace WebDriverLibrary.Steps
{
    public class StepForMainPage
    {
        IWebDriver driver;
        private const string SETTINGPAGE = "fwdandpop";
        private const string THEMES_PAGE = "oldthemes";


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
            string text = Services.Method();
            // mainPage.tLetter.SetText("hello");
            mainPage.tLetter.SetText(text);
            mainPage.bSend.Click();
        }

        public void WriteALetter()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
        }

        public void CloseWindowWithMessage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bCloseWindowMessage.Click();
        }
        public void WriteLetterWithEmoticonIcon(string addressee)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("emoji");
            mainPage.bEmojiButton.Click();
          //  Waiter.Wait();
            mainPage.bSecondEmoji.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//button[@string='1f600']")));
          //  Waiter.Wait();
            mainPage.bEmoji1.Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//button[@string='1f601']")));
           // Waiter.Wait();
            mainPage.bEmoji2.Click();
            Waiter.Wait();
            mainPage.bSend.Click();
        }


        public void WriteALetterWithAttach(string addressee, string path)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("letter with attech");
            mainPage.bAttachFile.Click();
            //mainPage.bSend.Click();
            IAutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            autoIT.Send(path);
            Thread.Sleep(7000);
            autoIT.Send("{ENTER}");
            Thread.Sleep(7000);
            mainPage.bSend.Click();
        }
        public void WriteALetterWithAttach2(string addressee, string path)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("letter with attech");
            mainPage.bAttachFile.Click();
            //mainPage.bSend.Click();
            IAutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            autoIT.Send(path);
            Thread.Sleep(7000);
            autoIT.Send("{ENTER}");
            Thread.Sleep(7000);

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

        public bool CheckLetterInBox()
        {
            IWebElement notSpamLetter = driver.FindElement(By.XPath("//b[contains(text(),'not a spam')]"));
            if (notSpamLetter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OpenInBox()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bInBox.Click();
        }
      
        public void OpenSettings()
        {
            MainPage mainPage = new MainPage(driver);
                     driver.Navigate().GoToUrl(mainPage.URL + SETTINGPAGE);
        }
        public void OpenGeneralSettings()
        {
            MainPage mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(mainPage.URL);
        }

        public void OpenThemes()
        {
            MainPage mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(mainPage.URL + THEMES_PAGE);
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

        public void OpenInbox()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.tSerchBar.SetText("in:inbox");
            mainPage.bSearch.Click();
        }

        public bool FindEmailInInbox(String topicLine)
        {
            IWebElement topic = driver.FindElement(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/.."));
            IWebElement notImpotant = driver.FindElement(By.XPath("//div[@aria-label='Неважное']"));
            if (topic != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CheckPresenceOfAlertForFileTooBig()
        {
            IWebElement alert = driver.FindElement(By.XPath("//div[@role='alertdialog']"));
            if (alert != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmojiInEmailBody()
        {
            IWebElement alert = driver.FindElement(By.XPath("//b[contains(text(),'emoji')]"));
            if (alert != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckSignature(string signature)
        {
            MainPage mainPage = new MainPage(driver);
            if (mainPage.tbSignature.GetText().Equals(signature))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StarredTopMessage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bStarMessage.Click();
        }

        public void OpenStarPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.lStarTitle.Click();
        }

        public void RemoveStarMessage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bNotStar.Click();
        }
        public bool CheckStarMessage()
        {
            IWebElement message = driver.FindElement(By.XPath("//span[contains(text(),'Станислав Лежнюк')]"));
            if (message != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public void IsStarSelect()
        //{
        //    MainPage mainPage = new MainPage(driver);
        //   // mainPage.bStar.
        //        mainPage.bStar.Ielement.GetAttribute("aria-label");
        //}

        //public void DeleteMessage(string topicLine)
        //{
        //    // IWebElement topic = driver.FindElement(By.XPath("div[contains(text(),'hi')]"));
        //    //   topic.Click();
        //    MainPage mainPage = new MainPage(driver);
        //    mainPage.bMark.Click();

        //}
    }
}
