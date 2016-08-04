using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;
using OpenQA.Selenium;
using Core.Driver;
using Core.Utils;
using GmailTest;

namespace WebDriver.Tests
{
    [TestFixture]
    public class TestClass
    {
        private string USEREMAIL = Data.usermail;
        private string USERPASSWORD = Data.userpassword;
        private string USEREMAIL2 = Data.usermail2;
        private string USERPASSWORD2 = Data.userpassword2;
        private string SPAMFOLDER = Data.spamFolder;
        private string USEREMAIL3 = Data.usermail3;
        private string USERPASSWORD3 = Data.userpassword3;
        private string SETTINGPAGE = Data.settingPage;
        private string TOPIC_LETTER_WITH_ATTACH = Data.topicLetterWithAttech;
        private string TOPIC_LETTER_WITHOUT_ATTACH = Data.topicLetterWithoutAttech;
        private string SIGNATURE = Data.signature;
        private string THEMES_FOR_VOCATION_RESPONDER = Data.themVocation;
        private string MESSAGE_FOR_VOCATION_RESPONDER = Data.messageVocation;
        private string TOPIC_EMOGI = Data.topicEmoji;
        public string debugPath = TestContext.CurrentContext.TestDirectory;
        public string browser = Data.browser;
        public string pathToLogFile;

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StemForSpamPage stepForSpamPage;
        StepsForSettingsPage stepForSettingsPage;
        StepForTrashPage stepForTrashPage;

        [SetUp]
        public void Init()
        {
            pathToLogFile = debugPath + Data.nameLogFile;
            logger = Logger.GetLogger(typeof(TestClass), pathToLogFile);
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver(browser);

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
            stepForMainPage.WriteALetter(USEREMAIL, TOPIC_LETTER_WITHOUT_ATTACH);
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.MarkTheLetter();
            Waiter.WaitElement();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL, TOPIC_LETTER_WITHOUT_ATTACH);
            Waiter.WaitElement();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmailAsSecondUser(USERPASSWORD);
            stepForSpamPage.GoToSpam(SPAMFOLDER);
            Waiter.WaitElement();
            Assert.True(stepForSpamPage.AssertSpam(USEREMAIL2));
            Waiter.WaitElement();
            stepForSpamPage.OpenLetterAndMarkNotSpam();

            logger.Log("[Test] SpamGmail() finished");
        }

        [Test]
        //[Ignore("ignore")] //3
        public void BigFileGmail()
        {
            logger.Log("[Test] BigFileGmail() started");

            string pathToBigFile = debugPath + "\\" + Data.nameBigFile;

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteALetterWithAttach2(USEREMAIL, pathToBigFile, TOPIC_LETTER_WITH_ATTACH);
            Waiter.WaitElement();
            Assert.IsTrue(stepForMainPage.CheckPresenceOfAlertForFileTooBig());

            logger.Log("[Test] BigFileGmail() finished");
        }

        [Test]
        // [Ignore("ignore")] //4
        public void ThemesGmail()
        {
            logger.Log("[Test] ThemesGmail() started");
            string pathToSmallFile = debugPath + "\\" + Data.nameSmallFile;

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.OpenThemes();
            stepForSettingsPage.ChangeThemeCustomImage(pathToSmallFile);
            Assert.IsTrue(stepForSettingsPage.CheckThemes());

            logger.Log("[Test] ThemesGmail() finished");
        }


        [Test]
        //   [Ignore("ignore")] //5
        public void SendEmailWithEmoji()
        {
            logger.Log("[Test] SendEmailWithEmoji() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteLetterWithEmoticonIcon(USEREMAIL, TOPIC_EMOGI);
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            Waiter.WaitElement();
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
            Waiter.WaitElement();
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
            Waiter.WaitElement();
            stepForSpamPage.MarkLetterNotSpam();
            Waiter.WaitElement();
            stepForMainPage.OpenInBox();
            Waiter.WaitElement();
            Assert.IsTrue(stepForMainPage.CheckLetterInBox());

            logger.Log("[Test] MarkItemAsNotASpam() finished");
        }
    }
}
