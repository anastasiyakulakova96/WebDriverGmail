using OpenQA.Selenium;
using Core.Elements;
using System;
using Core.Utils;

namespace Core
{
    public class Button : Element
    {
       
        public Button(By by, IWebDriver driver) : base(by, driver)
        {
            
        }

       
    }
}
