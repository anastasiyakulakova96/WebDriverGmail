﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Elements
{
    public class CheckBox : Element
    {
        public CheckBox(By by, IWebDriver driver, string name) : base(by, driver, name)
        {

        }
    }
}
