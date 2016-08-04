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
        public CheckBox cbFirstMessage { get; set; }
        public Button bCloseWindowMessage { get; set; }
        public Button bStarMessage { get; set; }
        public Button bStar { get; set; }
        public Label lStarTitle { get; set; }
        public Button bNotStar { get; set; }
      
        public string FirstEmoji
        {
            get
            {
                return "//button[@string='1f600']";
            }
        }
        public string SecondEmoji
        {
            get
            {
                return "//button[@string='1f601']";
            }
        }
        public string TextNotASpam
        {
            get
            {
                return "//b[contains(text(),'not a spam')]";
            }
        }
        public string InInbox
        {
            get
            {
              return  "in:inbox";
            }
        }
        public string NotImpotant
        {
            get
            {
                return "//div[@aria-label='Неважное']";
            }
        }
        public string BigFileAlert
        {
            get
            {
                return "//div[@role='alertdialog']";
            }
        }
        public string EmojiEmailBody
        {
            get
            {
                return "//b[contains(text(),'emoji')]";
            }
        }
        public string StarMessage
        {
            get
            {
                return "//span[contains(text(),'Станислав Лежнюк')]";
            }
        }
        public string VocationResponder
        {
            get
            {
                return "//b[contains(text(),'Vacation responder')]";
            }
        }

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

          bWriteEMail = new Button(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']"), driver, "bWriteEMail");
          //  bWriteEMail = new Button(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3222']"), driver, "bWriteEMail");
            bSend = new Button(By.XPath("//div[@class = 'T-I J-J5-Ji aoO T-I-atl L3']"), driver, "bSend");
            bMark = new Button(By.XPath("//div[@class = 'asl T-I-J3 J-J5-Ji']"), driver, "bMark");
            bMyAccount = new Button(By.XPath("//*[@id='gb']/div[1]/div[1]/div[2]/div[4]/div[1]/a/span"), driver, "bMyAccount");
            bExit = new Button(By.XPath("//*[@id='gb_71']"), driver, "bExit");
            bOtherAccount = new Button(By.XPath("//*[@id='account-chooser-link']"), driver, "bOtherAccount");
            bAddAccount = new Button(By.XPath("//*[@id='account-chooser-add-account']"), driver, "bAddAccount");
            bAddOneMoreAccount = new Button(By.XPath("//*[@id='account-chooser-add-account']"), driver, "bAddOneMoreAccount");
            bSettings = new Button(By.XPath("//div[@class ='aos T - I - J3 J - J5 - Ji']"), driver, "bAddOneMoreAccount");
            bSettingsFromDropDownMenu = new Button(By.XPath("//*[@id=':21']/div[1]"), driver, "bSettingsFromDropDownMenu");
            bFirstUser = new Button(By.XPath("//*[@id='choose-account-0']"), driver, "bFirstUser");
            bSecondUser = new Button(By.XPath("//*[@id='choose-account-1']"), driver, "bSecondUser");
            confirmButtonInNewTab = new Button(By.XPath("//input[@type='submit']"), driver, "confirmButtonInNewTab");
            bAttachFile = new Button(By.XPath("//div[@class='a1 aaA aMZ']"), driver, "bAttachFile");
            tSerchBar = new TextBox(By.XPath("//input[@id='gbqfq']"), driver, "tSerchBar");
            bSearch = new Button(By.XPath("//button[@id='gbqfb']"), driver, "bSearch");
            bAlertFileIsTooBig = new Button(By.XPath("//div[@role='alertdialog']"), driver, "bAlertFileIsTooBig");
            tRecipient = new TextBox(By.XPath("//textarea[@class='vO']"), driver, "tRecipient");
            tTopic = new TextBox(By.XPath("//input[@class='aoT']"), driver, "tTopic");
            tLetter = new TextBox(By.XPath("//div[@class='Am Al editable LW-avf']"), driver, "tLetter");
            cFirstCheckBox = new CheckBox(By.XPath("//div[@dir='ltr']"), driver, "cFirstCheckBox");
            bFirstMessage = new Button(By.XPath("//span[@email='forwarding-noreply@google.com']"), driver, "bFirstMessage");
            lForward = new Link(By.XPath("(//a[@target='_blank' and @rel='noreferrer'])[1]"), driver, "lForward");
            bEmojiButton = new Button(By.XPath("//div[@class='QT aaA aMZ']"), driver, "bEmojiButton");
            bEmoji1 = new Button(By.XPath("//button[@string='1f600']"), driver," bEmoji1");
            bEmoji2 = new Button(By.XPath("//button[@string='1f601']"), driver, "bEmoji2");
            bSecondEmoji = new Button(By.XPath("//button[@title='Эмоции']"), driver, "bSecondEmoji");
            bNotASpam = new Button((By.XPath("//div[contains(text(),'Не спам')]")), driver, "bNotASpam");
            bInBox = new Button((By.XPath("//a[contains(text(),'Входящие')]")), driver, "bInBox");
            tbSignature = new TextBox(By.XPath("//div[@class='gmail_signature']/div"), driver, "tbSignature");
            cbFirstMessage = new CheckBox(By.XPath("div[contains(text(),'hi')]"), driver, "cbFirstMessage");
            bCloseWindowMessage = new Button((By.XPath("//*[@ aria-label='Сохранить и закрыть']")), driver, "bCloseWindowMessage");
            bStarMessage = new Button((By.XPath("(//table[@class='F cf zt']//td[@class='apU xY'])[1]")), driver, "bStarMessage");
            lStarTitle = new Label((By.XPath("//*[@title='Помеченные']")), driver, "lStarTitle");
            bNotStar = new Button(By.XPath("//span[@title='Помеченные']"), driver, "bNotStar");
        }
    }
}
