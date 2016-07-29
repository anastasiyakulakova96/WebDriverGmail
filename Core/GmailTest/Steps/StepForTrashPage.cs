﻿using Core.Driver;
using GmailTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest.Steps
{
  public  class StepForTrashPage
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

        public void OpenTrash()
        {
            TrashPage trashPage = new TrashPage(driver);
            trashPage.tSerchBar.SetText("in:trash");
            trashPage.bSearch.Click();
        }

        public bool FindEmailInTrash(String topicLine)
        {
            IWebElement topic = driver.FindElement(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/.."));
           // if (ExpectedConditions.ElementIsVisible(topic) != null) 
           if(topic!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
