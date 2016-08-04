using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;
using OpenQA.Selenium;
using Core.Driver;
using Core.Utils;

namespace GmailTest.Tests
{
    [TestFixture]
    public class ForwardGmail_2
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
        StepsForSettingsPage stepForSettingsPage;
        StepForTrashPage stepForTrashPage;

        [SetUp]
        public void Init()
        {
            logger = Logger.GetLogger(typeof(ForwardGmail_2));
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver();

            stepForLogin = new StepForLoginPage(driver);
            stepForMainPage = new StepForMainPage(driver);

            stepForSettingsPage = new StepsForSettingsPage(driver);
            stepForTrashPage = new StepForTrashPage(driver);
        }

        [Test]
       //[Ignore("ignore")] //2
        public void ForwardGmailTest()
        {
            logger.Log("[Test] ForwardGmailTest() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL2, USERPASSWORD2);
            stepForMainPage.OpenSettings();
            stepForSettingsPage.SetForwardingToUserInSetting(USEREMAIL3);
            stepForSettingsPage.SentEmail();
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            Waiter.WaitElement();
            stepForMainPage.OpenMessage();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForMainPage.OpenSettings();
            stepForSettingsPage.ForwardACopyOfIncomingMailTo();
            Waiter.WaitElement();
            stepForSettingsPage.OpenFilterPage();
            stepForSettingsPage.CreateNewFilter();
            stepForSettingsPage.FillInNewFilterFrom(USEREMAIL);
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddAccaunt();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.WriteALetterWithAttach(USEREMAIL2, PATH_TO_SMALL_FILE,TOPIC_LETTER_WITH_ATTACH);
            Waiter.WaitElement();
            stepForMainPage.WriteALetter(USEREMAIL2,TOPIC_LETTER_WITHOUT_ATTACH);
            Waiter.WaitElement();
            stepForMainPage.LogOut();
            Waiter.WaitElement();
            stepForLogin.LoginGmail(USERPASSWORD2);
            Waiter.WaitElement();
            Assert.IsTrue(stepForMainPage.FindEmailInInbox(TOPIC_LETTER_WITHOUT_ATTACH));
            stepForTrashPage.OpenTrash();
            Waiter.WaitElement();
            Assert.IsTrue(stepForTrashPage.FindEmailInTrash(TOPIC_LETTER_WITH_ATTACH));
            Waiter.WaitElement();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmailAsSecondUser(USERPASSWORD3);
            Waiter.WaitElement();
            Assert.IsTrue(stepForMainPage.FindEmailInInbox(TOPIC_LETTER_WITHOUT_ATTACH));

            Waiter.WaitElement();
            stepForMainPage.LogOut();
            Waiter.WaitElement();
            stepForLogin.LoginGmail(USERPASSWORD2);
            Waiter.WaitElement();
            stepForMainPage.OpenSettings();
            stepForSettingsPage.DeleteEmail();
            Waiter.WaitElement();
            stepForSettingsPage.OpenFilterPage();
            Waiter.WaitElement();
            stepForSettingsPage.DeleteFilter();

            logger.Log("[Test] ForwardGmailTest() finished");
        }

        [TearDown]
        public void CleanUp()
        {
            logger.Log("[TearDown] CleanUp()");

            //Waiter.WaitElement();
            //stepForMainPage.LogOut();
            //Waiter.WaitElement();
            //stepForLogin.LoginGmail(USERPASSWORD2);
            //Waiter.WaitElement();
            //stepForMainPage.OpenSettings();
            //stepForSettingsPage.DeleteEmail();
            //Waiter.WaitElement();
            //stepForSettingsPage.OpenFilterPage();
            //Waiter.WaitElement();
            //stepForSettingsPage.DeleteFilter();
            Driver.CloseBrowser();

            logger.Close();
        }
    }
}
