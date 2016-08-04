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
    public class VacationGmail_14
    {
        private string USEREMAIL = Data.usermail;
        private string USERPASSWORD = Data.userpassword;
        private string USEREMAIL2 = Data.usermail2;
        private string USERPASSWORD2 = Data.userpassword2;
        private string USEREMAIL3 = Data.usermail3;
        private string USERPASSWORD3 = Data.userpassword3;
        private string THEMES_FOR_VOCATION_RESPONDER = Data.themVocation;
        private string MESSAGE_FOR_VOCATION_RESPONDER = Data.messageVocation;
        private string TOPIC_LETTER_WITHOUT_ATTACH = Data.topicLetterWithoutAttech;
        public string browser = Data.browser;
        public string pathToLogFile;
        public string debugPath = TestContext.CurrentContext.TestDirectory;

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StepsForSettingsPage stepForSettingsPage;

        [SetUp]
        public void Init()
        {
            pathToLogFile = debugPath + Data.nameLogFile;
            logger = Logger.GetLogger(typeof(VacationGmail_14), pathToLogFile);
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver(browser);

            stepForLogin = new StepForLoginPage(driver);
            stepForMainPage = new StepForMainPage(driver);
            stepForSettingsPage = new StepsForSettingsPage(driver);
        }

        [TearDown]
        public void CleanUp()
        {
            logger.Log("[TearDown] CleanUp()");

            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USERPASSWORD);
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.VacationResponderOff();
            Driver.CloseBrowser();

            logger.Close();
        }

        [Test]
        //  [Ignore("ignore")] //14
        public void VacationGmail()
        {
            logger.Log("[Test] VacationGmail() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.VacationResponderOn(THEMES_FOR_VOCATION_RESPONDER, MESSAGE_FOR_VOCATION_RESPONDER);
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.WriteALetter(USEREMAIL3, TOPIC_LETTER_WITHOUT_ATTACH);
            Assert.IsTrue(stepForMainPage.CheckVocationResponder());

            logger.Log("[Test] VacationGmail() finished");
        }
    }
}
