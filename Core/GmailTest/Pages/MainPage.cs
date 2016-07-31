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
    public class MainPage
    {

        private IWebDriver driver;

        private string urlForSettings = "https://mail.google.com/mail/#settings/";
        public string URL { get { return urlForSettings; } set { urlForSettings = value; } }

        public Button bWriteEMail { get; set; }
        public TextBox tRecipient { get; set; }
        public TextBox tTopic { get; set; }
        public TextBox tLetter { get; set; }
        public Button bSend { get; set; }
        public CheckBox cFirstCheckBox { get; set; }
        public Button bFirstMessage { get; set; }
        public Button confirmButtonInNewTab { get; set; }
        public Button bMark { get; set; }
        public Button bMyAccount { get; set; }
        public Button bExit { get; set; }
        public Button bOtherAccount { get; set; }
        public Button bAddOneMoreAccount { get; set; }
        public Button bFirstUser { get; set; }
        public Button bSecondUser { get; set; }
        public Button bSettings { get; set; }
        public Button bAddAccount { get; set; }
        public Button bSettingsFromDropDownMenu { get; set; }
        public Button bAttachFile { get; set; }
        public Link lForward { get; set; }
        public TextBox tSerchBar { get; set; }
        public Button bSearch { get; set; }
        public Button bAlertFileIsTooBig { get; set; }
        public Button bEmojiButton { get; set; }
        public Button bEmoji1 { get; set; }
        public Button bEmoji2 { get; set; }
        public Button bSecondEmoji { get; set; }
        public Button bNotASpam { get; set; }
        public Button bInBox { get; set; }
        public TextBox tbSignature { get; set; }


        // public TextBox tTopicEmoji { get; set; }

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            bWriteEMail = new Button(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']"), driver);
            bSend = new Button(By.XPath("//div[@class = 'T-I J-J5-Ji aoO T-I-atl L3']"), driver);
            bMark = new Button(By.XPath("//div[@class = 'asl T-I-J3 J-J5-Ji']"), driver);
            bMyAccount = new Button(By.XPath("//*[@id='gb']/div[1]/div[1]/div[2]/div[4]/div[1]/a/span"), driver);
            bExit = new Button(By.XPath("//*[@id='gb_71']"), driver);
            bOtherAccount = new Button(By.XPath("//*[@id='account-chooser-link']"), driver);
            bAddAccount =new Button(By.XPath("//*[@id='account-chooser-add-account']"), driver); 
            bAddOneMoreAccount = new Button(By.XPath("//*[@id='account-chooser-add-account']"), driver);
            bSettings = new Button(By.XPath("//div[@class ='aos T - I - J3 J - J5 - Ji']"), driver);
            bSettingsFromDropDownMenu = new Button(By.XPath("//*[@id=':21']/div[1]"), driver);
            bFirstUser = new Button(By.XPath("//*[@id='choose-account-0']"), driver);
            bSecondUser = new Button(By.XPath("//*[@id='choose-account-1']"), driver);
            confirmButtonInNewTab= new Button(By.XPath("//input[@type='submit']"), driver);
            bAttachFile= new Button(By.XPath("//div[@class='a1 aaA aMZ']"), driver);
            tSerchBar = new TextBox(By.XPath("//input[@id='gbqfq']"), driver);
            bSearch = new Button(By.XPath("//button[@id='gbqfb']"), driver);
            bAlertFileIsTooBig = new Button(By.XPath("//div[@role='alertdialog']"), driver);

            tRecipient = new TextBox(By.XPath("//textarea[@class='vO']"), driver);
            tTopic = new TextBox(By.XPath("//input[@class='aoT']"), driver);
            tLetter = new TextBox(By.XPath("//div[@class='Am Al editable LW-avf']"), driver);
           // cFirstCheckBox = new CheckBox(By.XPath("//*[@id=':2j']/div"), driver);
         cFirstCheckBox = new CheckBox(By.XPath("//div[@dir='ltr']"), driver);
            bFirstMessage = new Button(By.XPath("//span[@email='forwarding-noreply@google.com']"), driver);

            lForward = new Link(By.XPath("(//a[@target='_blank' and @rel='noreferrer'])[1]"), driver);
            bEmojiButton = new Button(By.XPath("//div[@class='QT aaA aMZ']"), driver);
            bEmoji1 = new Button(By.XPath("//button[@string='1f600']"), driver);
            bEmoji2 = new Button(By.XPath("//button[@string='1f601']"), driver);
            bSecondEmoji = new Button(By.XPath("//button[@title='Эмоции']"), driver);
             bNotASpam = new Button((By.XPath("//div[contains(text(),'Не спам')]")), driver);
            bInBox = new Button((By.XPath("//a[contains(text(),'Входящие')]")), driver);
        tbSignature = new TextBox(By.XPath("//div[@class='gmail_signature']/div"), driver);

        }
        
    }
}
