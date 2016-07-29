using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace Core.Elements
{
    public abstract class Element
    {
        protected TimeSpan timeout = TimeSpan.FromSeconds(30);
        protected By by;
        protected IWebDriver driver;

        public Element(By by, IWebDriver driver)
        {
            this.by = by;
            this.driver = driver;
        }

        public Element(By by, IWebDriver driver, TimeSpan timeout) : this(by, driver)
        {
            this.timeout = timeout;
        }

        public bool Click()
        {
            IWebElement element = null;
            if (TryFindElement(out element) && isClickable(element))
            {
                element.Click();
                return true;
            }
            return false;

        }

        public bool TryFindElement(out IWebElement element)
        {
            var wait = new WebDriverWait(driver, timeout);
            element = wait.Until(drv => drv.FindElement(by));
            //try
            //{
                //element = driver.FindElement(by);
            //}
            //catch (NoSuchElementException ex)
            //{
            //    return false;
            //}
            return true;
        }

        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public static bool isClickable(IWebElement webe)
        {
            var driver = Driver.Driver.GetDriver();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(2000));
                wait.Until(ExpectedConditions.ElementToBeClickable(webe));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
