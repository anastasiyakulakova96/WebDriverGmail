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
        Logger logger;

        StepForLoginPage stepForLogin;
        StepForMainPage stepForMainPage;
        StemForSpamPage stepForSpamPage;
        StepsForSettingsPage stepForSettingsPage;
        StepForTrashPage stepForTrashPage;

        private const string USEREMAIL = "anastasiyaliazhniuk@gmail.com";
        private const string USERPASSWORD = "meniti82";

        [SetUp]
        public void Init()
        {
            logger = Logger.GetLogger(typeof(StarGmail_13));
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
            Waiter.Wait();

            logger.Log("[Test] MarkAsStar() finished");
        }

    }
}
