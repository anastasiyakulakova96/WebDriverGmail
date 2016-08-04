using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Elements
{
    public class CheckBox : Element
    {
        IWebElement element = null;
        public CheckBox(By by, IWebDriver driver) : base(by, driver)
        {

        }
        public void Click()
        {
            base.Click();
        }
    }
}
