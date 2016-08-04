using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Core.Utils;

namespace Core.Elements
{
    public class TextBox : Element
    {
        public TextBox(By by, IWebDriver driver, string name) : base(by, driver, name)
        {

        }

        public bool SetText(String text)
        {
            IWebElement element = TryFindElement();
            if (element != null)
            {
                element.SendKeys(text);
                logger.Log("Set text: " + by);
                return true;
            }
            return false;
        }


        public string GetText()
        {
            IWebElement element = null;
            if (TryFindElement(out element))
            {
                logger.Log("Text of elements : " + by);
                return element.Text;
            }
            return null;
        }

        public void ClearText()
        {
            IWebElement element = null;
            if (TryFindElement(out element))
            {
                logger.Log("Clear text: " + by);
                element.Clear();
            }
            else
            {
                throw new Exception();

            }

        }
    }
}
