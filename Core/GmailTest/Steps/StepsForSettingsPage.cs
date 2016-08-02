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

namespace WebDriverLibrary.Steps
{
    class StepsForSettingsPage
    {
        public IWebDriver driver;
        private const string FILTERPAGE = "filters";

        public StepsForSettingsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetForwardingToUserInSetting(string addressee)
        {
            SettingsPage settingPage = new SettingsPage(driver);

            settingPage.bAddEmailForForwardingButton.Click();
            settingPage.tRecipient.SetText(addressee);
            settingPage.bNextToConfirmForwarding.Click();
        }

        public void SentEmail()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            settingPage.bContinueButtonOnConfirmationForwardWindow.Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.First());
            settingPage.bOKToConfirmForwarding.Click();
        }

        public void ForwardACopyOfIncomingMailTo()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.rbForwardACopyOfIncomingMail.Click();
            settingPage.bSaveChanges.Click();
        }

        public void CreateNewFilter()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.bCreateNewFilter.Click();
        }

        public void DeleteFilter()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.cbDeleteFilter.Click();
            settingPage.bDeleteFilter.Click();
            settingPage.bOk.Click();
        }

        public void OpenFilterPage()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            driver.Navigate().GoToUrl(settingPage.URL + FILTERPAGE);
        }


        public void FillInNewFilterFrom(string userName)
        {
            SettingsPage settingPage = new SettingsPage(driver);
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
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.lInstallTheme.Click();
            Waiter.Wait();
            settingPage.bMyPictures.Click();
            Waiter.Wait();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='KA-JQ']")));
            settingPage.bFrameChangeThemeLocator.Click();
            settingPage.bChooseFileFromComputer.Click();
            IAutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            autoIT.Send(path);
            Thread.Sleep(7000);
            autoIT.Send("{ENTER}");
            Thread.Sleep(7000);

        }

        public void ChooseThemes()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.lInstallTheme.Click();
            Waiter.Wait();
            settingPage.bChooseThemeBeach.Click();
        }

        public bool CheckThemes()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[contains(text(),'не поддерживается')]"));

            if (element != null)
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
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.rbSelectSignature.Click();
            Waiter.Wait();
            settingPage.tbxSignature.ClearText();
            settingPage.tbxSignature.SetText(signature);
            Waiter.Wait();
            settingPage.bSaveChanges.Click();
        }

        public void DeleteSignature()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.tbxSignature.ClearText();
            settingPage.rbNotSignature.Click();
            settingPage.bSaveChanges.Click();
        }

        public void DeleteEmail()
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.bDeleteEmail.Click();
            Waiter.Wait();
            settingPage.bOk.Click();
        }

        public void VacationResponderOn(string  themes,string text)
        {
            SettingsPage settingPage = new SettingsPage(driver);
            settingPage.rbSelectResponderOn.Click();
            settingPage.tThemeResponder.ClearText();
            settingPage.tThemeResponder.SetText(themes);
            settingPage.tBodyResponder.ClearText();
            settingPage.tBodyResponder.SetText(text);
            settingPage.bSaveChanges.Click();

        }

    }
}
