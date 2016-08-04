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
    public class StarGmail_13
    {
        private string USEREMAIL = Data.usermail;
        private string USERPASSWORD = Data.userpassword;
        public string browser = Data.browser;
        public string pathToLogFile;
        public string debugPath = TestContext.CurrentContext.TestDirectory;

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;

        [SetUp]
        public void Init()
        {
            pathToLogFile = debugPath + Data.nameLogFile;
            logger = Logger.GetLogger(typeof(StarGmail_13), pathToLogFile);
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver(browser);

            stepForLogin = new StepForLoginPage(driver);
            stepForMainPage = new StepForMainPage(driver);
        }

        [TearDown]
        public void CleanUp()
        {
            logger.Log("[TearDown] CleanUp()");

            stepForMainPage.OpenInBox();
            stepForMainPage.StarredTopMessage();
            Driver.CloseBrowser();

            logger.Close();
        }

        [Test]
        //   [Ignore("ignore")] //13
        public void MarkAsStar()
        {
            logger.Log("[Test] MarkAsStar() started");

            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.StarredTopMessage();
            stepForMainPage.OpenStarPage();
            Assert.IsTrue(stepForMainPage.CheckStarMessage());
            Waiter.WaitElement();

            logger.Log("[Test] MarkAsStar() finished");
        }
    }
}
