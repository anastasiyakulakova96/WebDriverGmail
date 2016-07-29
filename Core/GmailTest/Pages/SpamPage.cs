using Core;
using Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverLibrary.Pages
{
    public class SpamPage
    {
    //    [FindsBy(How = How.XPath, Using = "//input[@id = 'gbqfq']")]
    //    private IWebElement inputField;
        public TextBox tInputField { get; set; }


        //[FindsBy(How = How.XPath, Using = "//button[@class='gbqfb']")]
        //private IWebElement searchSpamFolder;
        public Button bSearchSpamFolder { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[text()='Настя Лежнюк']")]
        private IWebElement senderOfSpam;
      public Button bSenderOfSpam1 { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id=':l2']/div")] //доделать чтобы выбирало письмо по email
        //private IWebElement checkbox;
        public CheckBox cFirstCheckBox { get; set; }


        //[FindsBy(How = How.XPath, Using = "//*[@id=':5']/div[2]/div[1]/div[1]/div/div/div[3]/div")]
        //private IWebElement mark;
        public Button bMark { get; set; }

        private IWebDriver driver;

        public SpamPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

            bSearchSpamFolder = new Button(By.XPath("//button[@class='gbqfb']"), driver);
            //bSenderOfSpam = new Button(By.XPath("//span[text()='Настя Лежнюк']"), driver);
            bMark = new Button(By.XPath("//*[@id=':5']/div[2]/div[1]/div[1]/div/div/div[3]/div"), driver);
          //  name = "Настя Лежнюк"
                bSenderOfSpam1 = new Button(By.XPath("//span[text()='Настя Лежнюк']"),driver);

            tInputField = new TextBox(By.XPath("//input[@id = 'gbqfq']"), driver);
           
            cFirstCheckBox = new CheckBox(By.XPath("//*[@id=':l2']/div)"), driver);
        }

              public string FindSpamSender()
        {
            return senderOfSpam.GetAttribute("email").ToLower();
        }
    }
}
