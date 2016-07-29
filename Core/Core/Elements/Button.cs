using OpenQA.Selenium;
using Core.Elements;

namespace Core
{
    public class Button : Element
    {
        public Button(By by, IWebDriver driver) : base(by, driver)
        {

        }
    }
}
