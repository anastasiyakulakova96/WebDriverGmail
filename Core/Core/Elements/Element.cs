using Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace Core.Elements
{
    public abstract class Element
    {
        protected Logger logger = Logger.GetLogger();

        protected TimeSpan timeout = TimeSpan.FromSeconds(10);
        protected By by;
        protected IWebDriver driver;
        protected string name;

        public Element(By by, IWebDriver driver, string name)
        {
            this.by = by;
            this.driver = driver;
            this.name = name;
        }

        public Element(By by, IWebDriver driver, string name, TimeSpan timeout) : this(by, driver, name)
        {
            this.timeout = timeout;
        }

        public bool Click()
        {
            IWebElement element = null;
            if (TryFindElement(out element) && isClickable(element))
            {
                element.Click();
                logger.Log("name: " + name + " click: " + by);

                return true;
            }
            return false;

        }

        public bool TryFindElement(out IWebElement element)
        {
            element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                element = wait.Until(drv => drv.FindElement(by));
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                logger.Log("TimeoutException Element [" + GetType().Name + "] not found");
                return false;
            }
            catch (NoSuchElementException ex)
            {
                logger.Log("NoSuchElementException Element [" + GetType().Name + "] not found");
                return false;
            }
        }

        public IWebElement TryFindElement()
        {
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                element = wait.Until(drv => drv.FindElement(by));
                return element;
            }
            catch (NoSuchElementException ex)
            {
                logger.Log("NoSuchElementException Element [" + GetType().Name + "] not found");
                return element;
            }
        }

        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public bool isClickable(IWebElement webe)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(2000));
                wait.Until(ExpectedConditions.ElementToBeClickable(webe));
                return true;
            }
            catch (Exception e)
            {
                logger.Log("Exception Element [" + GetType().Name + "] is not clickable");
                return false;
            }
        }
    }
}
