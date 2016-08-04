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
        private string PATH_TO_SMALL_FILE = Data.pathToSmallFile;
        private string PATH_TO_BIG_FILE = Data.pathToBigFile;
        private string PATH_TO_SMALL_FILE2 = Data.pathToSmallFileForCheck;
        private string SIGNATURE = Data.signature;
        private string THEMES_FOR_VOCATION_RESPONDER = Data.themVocation;
        private string MESSAGE_FOR_VOCATION_RESPONDER = Data.messageVocation;

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StemForSpamPage stepForSpamPage;
        StepsForSettingsPage stepForSettingsPage;
        StepForTrashPage stepForTrashPage;

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
         [Ignore("ignore")] //1
        public void SpamGmail()
        {
            logger.Log("[Test] SpamGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL2, USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL);
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.MarkTheLetter();
            Waiter.WaitElement();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL);
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
       [Ignore("ignore")] //3
        public void BigFileGmail()
        {
            logger.Log("[Test] SpamGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteALetterWithAttach2(USEREMAIL, PATH_TO_BIG_FILE);
            Waiter.WaitElement();
            Assert.IsTrue(stepForMainPage.CheckPresenceOfAlertForFileTooBig());

            logger.Log("[Test] SpamGmail() finished");
        }

        [Test]
       [Ignore("ignore")] //4
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
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            Waiter.WaitElement();
            Assert.IsTrue(stepForMainPage.CheckEmojiInEmailBody());

            logger.Log("[Test] SendEmailWithEmoji() finished");
        }


        [Test]
        // [Ignore("ignore")] //6
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
