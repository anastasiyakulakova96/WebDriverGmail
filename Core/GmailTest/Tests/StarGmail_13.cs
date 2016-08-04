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

        Logger logger;
        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;

        [SetUp]
        public void Init()
        {
            logger = Logger.GetLogger(typeof(StarGmail_13));
            logger.Log("[SetUp] Init()");

            IWebDriver driver = Driver.GetDriver();

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
