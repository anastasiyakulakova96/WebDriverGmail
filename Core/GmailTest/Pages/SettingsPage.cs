using Core;
using Core.Driver;
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
    public class SettingsPage
    {
        private IWebDriver driver;

        public SettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

            bAddEmailForForwardingButton = new Button(By.XPath("//input[@type='button' and @act='add']"), driver);
            bNextToConfirmForwarding = new Button(By.XPath("//button[@class='J-at1-auR']"), driver);
            bContinueButtonOnConfirmationForwardWindow = new Button(By.XPath("//input[@type='submit']"), driver);
            bOKToConfirmForwarding = new Button(By.XPath("//button[@name='ok']"), driver);
            tRecipient = new TextBox(By.XPath("//div[@class='PN']/input"), driver);
            rbForwardACopyOfIncomingMail = new RadioButton(By.XPath("(//input[@type='radio' and @name='sx_em'])[2]"), driver);
            bCreateNewFilter = new Button(By.XPath("//td[@class='rG']/span[@class='sA'][1]"), driver);
            tFromWhoTextField = new TextBox(By.XPath("//input[@class='ZH nr aQa' ]"), driver);
            cbHasAttachementCheckBox = new CheckBox(By.XPath("(//span[@class='w-Pv ZG']/input[1])[1]"), driver);
            bCreateFilterButtonMovesToCreationForm = new Button(By.XPath("//div[@class='acM']"), driver);
            cbDelete = new CheckBox(By.XPath("(//div[@class='nH lZ']/input[@type='checkbox'])[5]"), driver);
            cbMarkAsImportantCheckBox = new CheckBox(By.XPath("(//div[@class='nH lZ']/input[@type='checkbox'])[7]"), driver);
            bCreateFilter = new Button((By.XPath("//div[contains(text(),'Создать фильтр')]")), driver);

            //class="f0 ou"
            //baa=new Button(By.ClassName("f0 ou"), driver);

        }

        private string urlForSettings = "https://mail.google.com/mail/#settings/";
        public string URL { get { return urlForSettings; } set { urlForSettings = value; } }

        public Button bAddEmailForForwardingButton { get; set; }
        public TextBox tRecipient { get; set; }
        public Button bNextToConfirmForwarding { get; set; }
        public Button bContinueButtonOnConfirmationForwardWindow { get; set; }
        public Button bOKToConfirmForwarding { get; set; }
        public RadioButton rbForwardACopyOfIncomingMail { get; set; }
        public Button bCreateNewFilter { get; set; }
        public TextBox tFromWhoTextField { get; set; }
        public CheckBox cbHasAttachementCheckBox { get; set; }
        public Button bCreateFilterButtonMovesToCreationForm { get; set; }
        public CheckBox cbDelete { get; set; }
        public CheckBox cbMarkAsImportantCheckBox { get; set; }
        public Button bCreateFilter { get; set; }
        //  public Button baa { get; set; }

    }
}
