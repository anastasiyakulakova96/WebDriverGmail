using Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverLibrary.Steps
{
    public static class Waiter
    {
        public static  IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void Wait()
        {
            // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            // WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 100));
            System.Threading.Thread.Sleep(5000);
            // wait.Until(By.Id("login"));
        }
    }
}
