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
  public  class StepForTrashPage
    {
        IWebDriver driver;

        public StepForTrashPage(IWebDriver driver)
        {
            this.driver = driver;
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
            IWebElement impotant = driver.FindElement(By.XPath("//div[@aria-label='Отмечено как важное потому, что подходит под условия одного из ваших фильтров важности.']"));
                   if (topic!=null)
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
