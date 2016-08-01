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
            bSaveChanges = new Button(By.XPath("//button[@guidedhelpid='save_changes_button']"), driver);
            lInstallTheme = new Link(By.XPath("//a[@class='e NvzLyc']"), driver);
            bMyPictures = new Button(By.XPath("//div[@class='J-J5-Ji T-I T-I-ax7 a94']"), driver);
            bFrameChangeThemeLocator = new Button((By.XPath("//div[contains(text(),'Загрузка фото')]")), driver);
            bChooseFileFromComputer = new Button((By.XPath("//div[contains(text(),'Выберите файл на компьютере')]")), driver);
            bChooseThemeBeach = new Button(By.XPath("//div[contains(text(),'Lake Tahoe')]"), driver);
            rbSelectSignature = new RadioButton(By.XPath("//*[@name='sx_sg'][@value='1']"), driver);
            rbNotSignature=new RadioButton(By.XPath("//*[@name='sx_sg'][@value='0']"), driver);
            tbxSignature = new TextBox(By.XPath("//div[@aria-label='Подпись']"), driver);
            // btSaveChanges = new Button(By.XPath("//button[@guidedhelpid='save_changes_button']"), driver);
            bOk = new Button(By.XPath("//button[contains(text(),'ОК')]"), driver);
            bDeleteEmail = new Button(By.XPath("//option[contains(text(),' nastyakylakova96@gmail.com')]"), driver);
            cbDeleteFilter = new CheckBox(By.XPath("//input[@type='checkbox']"), driver);
            bDeleteFilter = new Button(By.XPath("//button[contains(text(),'Удалить')]"), driver);
            rbSelectResponderOn = new RadioButton(By.XPath("//label[contains(text(), 'Включить автоответчик')]/ancestor::td/preceding-sibling::td/input"), driver);
            tThemeResponder = new TextBox(By.XPath("//input[@aria-label='Тема']"), driver);
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
        public Button bSaveChanges { get; set; }
        public Link lInstallTheme { get; set; }
        public Button bMyPictures { get; set; }
        public Button bFrameChangeThemeLocator { get; set; }
        public Button bChooseFileFromComputer { get; set; }
        public TextBox tErrorFile { get; set; }
        public Button bChooseThemeBeach { get; set; }
        public RadioButton rbSelectSignature { get; set; }
        public RadioButton rbNotSignature { get; set; }
        public TextBox tbxSignature { get; set; }
        public Button bDeleteEmail { get; set; }
        public Button bOk { get; set; }
        public CheckBox cbDeleteFilter { get; set; }
        public Button bDeleteFilter { get; set; }
        //  public Button btSaveChanges { get; set; }
        public RadioButton rbSelectResponderOn { get; set; }
        public TextBox tThemeResponder { get; set; }
 


    }
}
