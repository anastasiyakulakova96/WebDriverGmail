using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;
using OpenQA.Selenium;
using Core.Driver;
using Core.Utils;

namespace WebDriver.Tests
{
    [TestFixture]
    public class TestClass
    {
        Logger logger;

        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StemForSpamPage stepForSpamPage;
        StepsForSettingsPage stepForSettingsPage;
        StepForTrashPage stepForTrashPage;

        private const string USEREMAIL = "anastasiyaliazhniuk@gmail.com";
        private const string USERPASSWORD = "meniti82";
        private const string ADDRESSEE = "s.lezhnyuk@gmail.com";
        private const string USEREMAIL2 = "s.lezhnyuk@gmail.com";
        private const string USERPASSWORD2 = "m1am1g0s";
        private const string SPAMFOLDER = "in:spam";
        private const string USEREMAIL3 = "nastyakylakova96@gmail.com";
        private const string USERPASSWORD3 = "meniti82";
        private const string SETTINGPAGE = "fwdandpop";
        private const string TOPIC_LETTER_WITH_ATTACH = "letter with attech";
        private const string TOPIC_LETTER_WITHOUT_ATTACH = "hi";
        private const string PATH_TO_SMALL_FILE = @"g:\свадьба.xlsx";
        private const string PATH_TO_BIG_FILE = @"g:\1.rar";
        private const string PATH_TO_SMALL_FILE2 = @"g:\DSC_8250.jpg";
        private const string SIGNATURE = "nastya";
        private const string THEMES_FOR_VOCATION_RESPONDER = "Vacation responder";
        private const string MESSAGE_FOR_VOCATION_RESPONDER = "Vacation responder on";


        [SetUp]
        public void Init()
        {
            logger = Logger.GetLogger(typeof(TestClass));
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver();

            stepForLogin = new StepForLoginPage(driver);
            stepForMainPage = new StepForMainPage(driver);
            stepForSpamPage = new StemForSpamPage(driver);
            stepForSettingsPage = new StepsForSettingsPage(driver);
            stepForTrashPage = new StepForTrashPage(driver);

        }

        [TearDown]
        public void CleanUp()
        {
            logger.Log("[TearDown] CleanUp()");

            Driver.CloseBrowser();

            logger.Close();
        }

        [Test]
     //   [Ignore("ignore")] //1
        public void SpamGmail()
        {
            logger.Log("[Test] SpamGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL2, USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.MarkTheLetter();
            Waiter.Wait();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail2(USERPASSWORD);
            stepForSpamPage.GoToSpam(SPAMFOLDER);
            Waiter.Wait();
            Assert.True(stepForSpamPage.AssertSpam(USEREMAIL2));
            Waiter.Wait();
            stepForSpamPage.OpenLetterAndMarkNotSpam();

            // steps.NotASpam();
            //  steps.CloseBrowser();
            // steps.InitBrowser();
            logger.Log("[Test] SpamGmail() finished");
        }

     
        [Test]
       // [Ignore("ignore")] //3
        public void BigFileGmail()
        {
            logger.Log("[Test] SpamGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteALetterWithAttach2(USEREMAIL, PATH_TO_BIG_FILE);
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckPresenceOfAlertForFileTooBig());

            logger.Log("[Test] SpamGmail() finished");
        }

        [Test]
      //  [Ignore("ignore")] //4
        public void ThemesGmail()
        {
            logger.Log("[Test] ThemesGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.OpenThemes();
            stepForSettingsPage.ChangeThemeCustomImage(PATH_TO_SMALL_FILE);
            Assert.IsTrue(stepForSettingsPage.CheckThemes());

            logger.Log("[Test] ThemesGmail() finished");
        }


        [Test]
       // [Ignore("ignore")] //5
        public void SendEmailWithEmoji()
        {
            logger.Log("[Test] SendEmailWithEmoji() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteLetterWithEmoticonIcon(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckEmojiInEmailBody());

            logger.Log("[Test] SendEmailWithEmoji() finished");
        }


        [Test]
        [Ignore("ignore")] //6
        public void ChangeUserTheme()
        {
            logger.Log("[Test] ChangeUserTheme() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.OpenThemes();
            Waiter.Wait();
            stepForSettingsPage.ChooseThemes();
            //выбрать любую тему

            logger.Log("[Test] ChangeUserTheme() finished");
        }

        [Test]
      //  [Ignore("ignore")] //11
        public void MarkItemAsNotASpam()
        {
            logger.Log("[Test] MarkItemAsNotASpam() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.MarkTheLetter();
            stepForSpamPage.GoToSpam(SPAMFOLDER);
            Waiter.Wait();
            stepForSpamPage.MarkLetterNotSpam();
            Waiter.Wait();
            stepForMainPage.OpenInBox();
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckLetterInBox());

            logger.Log("[Test] MarkItemAsNotASpam() finished");
        }


        [Test]
        //  [Ignore("ignore")] //14
        public void VacationGmail()
        {
            logger.Log("[Test] VacationGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.VacationResponderOn(THEMES_FOR_VOCATION_RESPONDER, MESSAGE_FOR_VOCATION_RESPONDER);
            Waiter.Wait();
            stepForMainPage.LogOut();

            logger.Log("[Test] VacationGmail() finished");
        }
        


    }
}
