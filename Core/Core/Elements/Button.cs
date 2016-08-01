using OpenQA.Selenium;
using Core.Elements;
using System;

namespace Core
{
    public class Button : Element
    {
        public Button(By by, IWebDriver driver) : base(by, driver)
        {

        }

        //public string GetAttribute()
        //{
        //    IWebElement element = null;
        //    if (TryFindElement(out element))
        //    {
        //       return element.GetAttribute();
        //    }
        //    else
        //    {
        //        throw new Exception();

        //    }
        //}
    }
}
