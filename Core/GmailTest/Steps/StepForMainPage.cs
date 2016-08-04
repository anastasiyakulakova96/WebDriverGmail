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

        public void WriteALetter(string addressee, string topic)
        {
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText(topic);
            string text = Services.GetCityById();
            mainPage.tLetter.SetText(text);
            mainPage.bSend.Click();
        }

        public void WriteALetter()
        {
            mainPage.bWriteEMail.Click();
        }

        public void CloseWindowWithMessage()
        {
            mainPage.bCloseWindowMessage.Click();
        }

        public void WriteLetterWithEmoticonIcon(string addressee, string topic)
        {
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText(topic);
            mainPage.bEmojiButton.Click();
            mainPage.bSecondEmoji.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(mainPage.FirstEmoji)));
            mainPage.bEmoji1.Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(mainPage.SecondEmoji)));
            mainPage.bEmoji2.Click();
            Waiter.WaitElement();
            mainPage.bSend.Click();
        }

        public void WriteALetterWithAttach(string addressee, string path, string topic)
        {
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText(topic);
            mainPage.bAttachFile.Click();
            IAutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            autoIT.Send(path);
            Thread.Sleep(7000);
            autoIT.Send("{ENTER}");
            Thread.Sleep(7000);
            mainPage.bSend.Click();
        }
        public void WriteALetterWithAttach2(string addressee, string path, string topic)
        {
            mainPage.bWriteEMail.Click();
            mainPage.tRecipient.SetText(addressee);
            mainPage.tTopic.SetText(topic);
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
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
            mainPage.bOtherAccount.Click();
            mainPage.bAddOneMoreAccount.Click();
        }

        public void LogOutWithAddAccaunt()
        {
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
            mainPage.bAddAccount.Click();
        }

        public void LogOut()
        {
            mainPage.bMyAccount.Click();
            mainPage.bExit.Click();
        }

        public void MarkTheLetter()
        {
            mainPage.cFirstCheckBox.Click();
            mainPage.bMark.Click();
        }

        public bool CheckLetterInBox()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mainPage.TextNotASpam)));
            Waiter.WaitElement(10000);

            if (driver.FindElements(By.XPath(mainPage.TextNotASpam)).Count() != 0)
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
            mainPage.bInBox.Click();
        }

        public void OpenSettings()
        {
            driver.Navigate().GoToUrl(mainPage.URL + SETTINGPAGE);
        }
        public void OpenGeneralSettings()
        {
            driver.Navigate().GoToUrl(mainPage.URL);
        }

        public void OpenThemes()
        {
            driver.Navigate().GoToUrl(mainPage.URL + THEMES_PAGE);
        }

        public void OpenMessage()
        {
            mainPage.bFirstMessage.Click();
            mainPage.lForward.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            mainPage.confirmButtonInNewTab.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.First());
        }

        public void OpenInbox()
        {
            mainPage.tSerchBar.SetText(mainPage.InInbox);
            mainPage.bSearch.Click();
        }

        public bool FindEmailInInbox(String topicLine)
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/..")));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mainPage.NotImpotant)));

            if (driver.FindElements(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/..")).Count != 0
                && driver.FindElements(By.XPath(mainPage.NotImpotant)).Count != 0)
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
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mainPage.BigFileAlert)));
            if (driver.FindElements(By.XPath(mainPage.BigFileAlert)).Count != 0)
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
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mainPage.EmojiEmailBody)));
            Waiter.WaitElement(10000);
            if (driver.FindElements(By.XPath(mainPage.EmojiEmailBody)).Count != 0)
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
            mainPage.bStarMessage.Click();
        }

        public void OpenStarPage()
        {
            mainPage.lStarTitle.Click();
        }

        public void RemoveStarMessage()
        {
            mainPage.bNotStar.Click();
        }
        public bool CheckStarMessage()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mainPage.StarMessage)));
            if (driver.FindElements(By.XPath(mainPage.StarMessage)).Count != 0)
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
            //  WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(),'Vacation responder')]")));
            Waiter.WaitElement(50000);

            if (driver.FindElements(By.XPath(mainPage.VocationResponder)).Count() != 0)
            {
                return true;
            }
            return false;
        }
    }
}
