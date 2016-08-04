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
        MainPage mainPage;

        private const string SETTINGPAGE = "fwdandpop";
        private const string THEMES_PAGE = "oldthemes";

        public StepForMainPage(IWebDriver driver)
        {
            this.driver = driver;
            mainPage = new MainPage(driver);
        }

        public void WriteALetter(string addressee,string topic)
        {
            //MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("hi");
            string text = Services.Method();
            mainPage.tLetter.SetText(text);
            mainPage.bSend.Click();
        }

        public void WriteALetter()
        {
            //MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
        }

        public void CloseWindowWithMessage()
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.bCloseWindowMessage.Click();
        }

        public void WriteLetterWithEmoticonIcon(string addressee,string topic)
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText(topic);
            mainPage.bEmojiButton.Click();
            mainPage.bSecondEmoji.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(mainPage.firstEmoji)));
            mainPage.bEmoji1.Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(mainPage.secondEmoji)));
            mainPage.bEmoji2.Click();
            Waiter.WaitElement();
            mainPage.bSend.Click();
        }

        public void WriteALetterWithAttach(string addressee, string path)
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("letter with attech");
            mainPage.bAttachFile.Click();
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
            // MainPage mainPage = new MainPage(driver);
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText("letter with attech");
            mainPage.bAttachFile.Click();
            IAutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            autoIT.Send(path);
            Thread.Sleep(7000);
            autoIT.Send("{ENTER}");
            Thread.Sleep(7000);
        }

        public void LogOutWithAddOneMoreAccount()
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
            mainPage.bOtherAccount.Click();
            mainPage.bAddOneMoreAccount.Click();
        }

        public void LogOutWithAddAccaunt()
        {
            //  MainPage mainPage = new MainPage(driver);
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
            mainPage.bAddAccount.Click();
        }

        public void LogOut()
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
        }

        public void MarkTheLetter()
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.cFirstCheckBox.Click();
            mainPage.bMark.Click();
        }

        public bool CheckLetterInBox()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(),'not a spam')]")));

            if (driver.FindElements(By.XPath("//b[contains(text(),'not a spam')]")).Count() != 0)
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
            // MainPage mainPage = new MainPage(driver);
            mainPage.bInBox.Click();
        }

        public void OpenSettings()
        {
            // MainPage mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(mainPage.URL + SETTINGPAGE);
        }
        public void OpenGeneralSettings()
        {
            // MainPage mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(mainPage.URL);
        }

        public void OpenThemes()
        {
            // MainPage mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(mainPage.URL + THEMES_PAGE);
        }

        public void OpenMessage()
        {
            //  MainPage mainPage = new MainPage(driver);
            mainPage.bFirstMessage.Click();
            mainPage.lForward.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            mainPage.confirmButtonInNewTab.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.First());
        }

        public void OpenInbox()
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.tSerchBar.SetText("in:inbox");
            mainPage.bSearch.Click();
        }

        public bool FindEmailInInbox(String topicLine)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/..")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@aria-label='Неважное']")));

            if (driver.FindElements(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/..")).Count != 0
                && driver.FindElements(By.XPath("//div[@aria-label='Неважное']")).Count != 0)
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='alertdialog']")));
            if (driver.FindElements(By.XPath("//div[@role='alertdialog']")).Count != 0)
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='alertdialog']")));
            if (driver.FindElements(By.XPath("//div[@role='alertdialog']")).Count != 0)
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
            //MainPage mainPage = new MainPage(driver);
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
            //  MainPage mainPage = new MainPage(driver);
            mainPage.bStarMessage.Click();
        }

        public void OpenStarPage()
        {
            //MainPage mainPage = new MainPage(driver);
            mainPage.lStarTitle.Click();
        }

        public void RemoveStarMessage()
        {
            // MainPage mainPage = new MainPage(driver);
            mainPage.bNotStar.Click();
        }
        public bool CheckStarMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'Станислав Лежнюк')]")));
            if (driver.FindElements(By.XPath("//span[contains(text(),'Станислав Лежнюк')]")).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckVocationResponder()
        {
            //MainPage mainPage = new MainPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(),'Vacation responder')]")));
            if (driver.FindElements(By.XPath("//b[contains(text(),'Vacation responder')]")).Count() != 0)
            {
                return true;
            }
            return false;
        }
    }
}
