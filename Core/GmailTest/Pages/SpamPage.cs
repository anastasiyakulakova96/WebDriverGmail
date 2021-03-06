﻿using Core;
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
        private IWebDriver driver;

        public TextBox tInputField { get; set; }
        public Button bSearchSpamFolder { get; set; }
        public Button bNotASpam { get; set; }
        public Button bOK { get; set; }
        public Button bSenderOfSpam1 { get; set; }
        public CheckBox cFirstCheckBox { get; set; }
        public Button bMark { get; set; }
        public Button bFirstMessage { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[text()='Станислав Лежнюк']")]
        private IWebElement senderOfSpam;
        public string FirstCheckBox
        {
            get
            {
                return "//div[@dir='ltr']";
            }
        }

        public SpamPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

            bSearchSpamFolder = new Button(By.XPath("//button[@class='gbqfb']"), driver, "bSearchSpamFolder");
            bMark = new Button(By.XPath("//*[@id=':5']/div[2]/div[1]/div[1]/div/div/div[3]/div"), driver, "bMark");
            bSenderOfSpam1 = new Button(By.XPath("//span[text()='Настя Лежнюк']"), driver, "bSenderOfSpam1");
            tInputField = new TextBox(By.XPath("//input[@id = 'gbqfq']"), driver, "tInputField");
            bNotASpam = new Button((By.XPath("//div[contains(text(),'Не спам')]")), driver, "bNotASpam");
            cFirstCheckBox = new CheckBox(By.XPath("//div[@dir='ltr']"), driver, "cFirstCheckBox");
            bFirstMessage = new Button((By.XPath("//span[contains(text(),'Удалить все письма со спамом')]")), driver, "bFirstMessage");
            bOK = new Button((By.XPath("//button[contains(text(),'ОК')]")), driver, "bOK");
        }

        public string FindSpamSender()
        {
            return senderOfSpam.GetAttribute("email").ToLower();
        }
    }
}
