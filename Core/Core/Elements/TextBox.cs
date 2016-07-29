using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Elements
{
    public class TextBox : Element
    {
        public TextBox(By by, IWebDriver driver) : base(by, driver)
        {

        }

        public bool SetText(String text)
        {
            IWebElement element = null;
            if (TryFindElement(out element))
            {
                element.SendKeys(text);
                return true;
            }
            return false;
        }

        public bool CanSetText(By id)
        {
            return false;
        }

       
    }
}
