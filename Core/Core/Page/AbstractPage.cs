using OpenQA.Selenium;

namespace Core.Page
{
    public abstract class AbstractPage
    {
        public abstract void OpenStartPage();

        public bool IsElementPresent(By locator)
        {
            return Core.Driver.Driver.CreatDriver().FindElements(locator).Count > 0;
        }

    }
}
