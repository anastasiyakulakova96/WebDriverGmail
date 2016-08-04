using OpenQA.Selenium;
using Core.Elements;
using System;
namespace Core.Elements
{
    public class Label : Element
    {
        public Label(By by, IWebDriver driver, string name) : base(by, driver, name)
        {

        }
    }
}
