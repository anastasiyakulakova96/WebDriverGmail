using AutoItX3Lib;
using Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverLibrary.Pages;
using GmailTest;
using System.Windows.Forms;

namespace WebDriverLibrary.Steps
{
    class StepsForSettingsPage
    {
        public IWebDriver driver;
        SettingsPage settingPage;

        private string FILTERPAGE = Data.filterPage;

        public StepsForSettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            settingPage = new SettingsPage(driver);
        }

        public void SetForwardingToUserInSetting(string addressee)
        {
            settingPage.bAddEmailForForwardingButton.Click();
            settingPage.tRecipient.SetText(addressee);
            settingPage.bNextToConfirmForwarding.Click();
        }

        public void SentEmail()
        {
            //Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            settingPage.bContinueButtonOnConfirmationForwardWindow.Click();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            //Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.First());
            settingPage.bOKToConfirmForwarding.Click();
        }

        public void ForwardACopyOfIncomingMailTo()
        {
            settingPage.rbForwardACopyOfIncomingMail.Click();
            settingPage.bSaveChanges.Click();
        }

        public void CreateNewFilter()
        {
            settingPage.bCreateNewFilter.Click();
        }

        public void DeleteFilter()
        {
            settingPage.cbDeleteFilter.Click();
            settingPage.bDeleteFilter.Click();
            settingPage.bOk.Click();
        }

        public void OpenFilterPage()
        {
            driver.Navigate().GoToUrl(settingPage.URL + FILTERPAGE);
        }


        public void FillInNewFilterFrom(string userName)
        {
            settingPage.tFromWhoTextField.SetText(userName);
            settingPage.cbHasAttachementCheckBox.Click();
            settingPage.bCreateFilterButtonMovesToCreationForm.Click();
            settingPage.cbDelete.Click();
            settingPage.cbMarkAsImportantCheckBox.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            settingPage.bCreateFilter.Click();
        }

        public void ChangeThemeCustomImage(string path)
        {
            settingPage.lInstallTheme.Click();
            Waiter.WaitElement();
            settingPage.bMyPictures.Click();
            Waiter.WaitElement();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(settingPage.Frame)));
            settingPage.bFrameChangeThemeLocator.Click();
            settingPage.bChooseFileFromComputer.Click();
            SendKeys.SendWait(path);
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            //IAutoItX3 autoIT = new AutoItX3();
            //autoIT.WinActivate("File Upload");
            //autoIT.Send(path);
            //Thread.Sleep(7000);
            //autoIT.Send("{ENTER}");
            //Thread.Sleep(7000);

        }

        public void ChooseThemes()
        {
            settingPage.lInstallTheme.Click();
            Waiter.WaitElement();
            settingPage.bChooseThemeBeach.Click();
        }

        public bool CheckThemes()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(settingPage.ThemMessage)));

            if (driver.FindElements(By.XPath(settingPage.ThemMessage)).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EnterSignature(string signature)
        {
            settingPage.rbSelectSignature.Click();
            Waiter.WaitElement();
            settingPage.tbxSignature.ClearText();
            settingPage.tbxSignature.SetText(signature);
            Waiter.WaitElement();
            settingPage.bSaveChanges.Click();
        }

        public void DeleteSignature()
        {
            settingPage.tbxSignature.ClearText();
            settingPage.rbNotSignature.Click();
            settingPage.bSaveChanges.Click();
        }

        public void DeleteEmail()
        {
            settingPage.bDeleteEmail.Click();
            Waiter.WaitElement();
            settingPage.bOk.Click();
        }

        public void VacationResponderOn(string themes, string text)
        {
            settingPage.rbSelectResponderOn.Click();
            settingPage.tThemeResponder.ClearText();
            settingPage.tThemeResponder.SetText(themes);
            settingPage.tBodyResponder.ClearText();
            settingPage.tBodyResponder.SetText(text);
            settingPage.bSaveChanges.Click();

        }

        public void VacationResponderOff()
        {
            settingPage.rbSelectResponderOff.Click();
            settingPage.bSaveChanges.Click();
        }
    }
}
