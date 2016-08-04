using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;
using Core.Driver;
using OpenQA.Selenium;
using Core.Utils;

namespace GmailTest.Tests
{
    [TestFixture]
    public class SignatureGmail_12
    {
        private string USEREMAIL = Data.usermail;
        private string USERPASSWORD = Data.userpassword;
        private string SIGNATURE = Data.signature;
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
            logger = Logger.GetLogger(typeof(SignatureGmail_12), pathToLogFile);
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

            stepForMainPage.CloseWindowWithMessage();
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.DeleteSignature();
            Driver.CloseBrowser();

            logger.Close();
        }

        [Test]
        //  [Ignore("ignore")] //12
        public void CheckingSignature()
        {
            logger.Log("[Test] CheckingSignature() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.EnterSignature(SIGNATURE);
            Waiter.WaitElement();
            stepForMainPage.WriteALetter();
            Waiter.WaitElement();
            stepForMainPage.CheckSignature(SIGNATURE);
            Assert.IsTrue(stepForMainPage.CheckSignature(SIGNATURE));

            logger.Log("[Test] CheckingSignature() finished");
        }
    }
}
