using OpenQA.Selenium;

namespace Core.Page
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public abstract void OpenStartPage();

        public bool IsElementPresent(By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

    }
}
