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

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StepsForSettingsPage stepForSettingsPage;

        [SetUp]
        public void Init()
        {
            logger = Logger.GetLogger(typeof(SignatureGmail_12));
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver();

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
