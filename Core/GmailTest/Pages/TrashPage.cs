using Core;
using Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest.Pages
{
    public class TrashPage
    {
        private IWebDriver driver;

        public TextBox tSerchBar { get; set; }
        public Button bSearch { get; set; }
        public string Important
        {
            get
            {
                return "//div[@aria-label='Отмечено как важное потому, что подходит под условия одного из ваших фильтров важности.']";
            }
        }

        public TrashPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

            tSerchBar = new TextBox(By.XPath("//input[@id='gbqfq']"), driver);
            bSearch = new Button(By.XPath("//button[@id='gbqfb']"), driver);
        }
    }
}
