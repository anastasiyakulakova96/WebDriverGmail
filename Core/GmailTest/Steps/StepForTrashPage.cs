using Core.Driver;
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
    public class StepForTrashPage
    {
        IWebDriver driver;
        TrashPage trashPage;

        public StepForTrashPage(IWebDriver driver)
        {
            this.driver = driver;
            trashPage = new TrashPage(driver);
        }

        public void OpenTrash()
        {
            trashPage.tSerchBar.SetText("in:trash");
            trashPage.bSearch.Click();
        }

        public bool FindEmailInTrash(String topicLine)
        {
            if (driver.FindElements(By.XPath("//span//b[contains(text(),'" + topicLine + "')]/..")).Count != 0 && driver.FindElements(By.XPath(trashPage.Important)).Count != 0)
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
