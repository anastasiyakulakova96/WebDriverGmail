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
        private string USEREMAIL3 = Data.usermail3;
        private string USERPASSWORD3 = Data.usermail3;
        private string THEMES_FOR_VOCATION_RESPONDER = Data.themVocation;
        private string MESSAGE_FOR_VOCATION_RESPONDER = Data.messageVocation;

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StepsForSettingsPage stepForSettingsPage;

        [SetUp]
        public void Init()
        {
            logger = Logger.GetLogger(typeof(VacationGmail_14));
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
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.VacationResponderOn(THEMES_FOR_VOCATION_RESPONDER, MESSAGE_FOR_VOCATION_RESPONDER);
            Waiter.WaitElement();
            stepForMainPage.LogOutWithAddOneMoreAccount();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteALetter(USEREMAIL);
            Assert.IsTrue(stepForMainPage.CheckVocationResponder());

            logger.Log("[Test] VacationGmail() finished");
        }
    }
}
