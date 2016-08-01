using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;

namespace GmailTest.Tests
{
    [TestFixture]
   public class StarGmail
    {
        StepForLoginPage stepForLogin = new StepForLoginPage();
        StepForMainPage stepForMainPage = new StepForMainPage();
        StemForSpamPage stepForSpamPage = new StemForSpamPage();
        StepsForSettingsPage stepForSettingsPage = new StepsForSettingsPage();
        StepForTrashPage stepForTrashPage = new StepForTrashPage();

        private const string USEREMAIL = "anastasiyaliazhniuk@gmail.com";
        private const string USERPASSWORD = "meniti82";

        [SetUp]
        public void Init()
        {
            stepForLogin.InitBrowser();
            stepForMainPage.InitBrowser();
            stepForSpamPage.InitBrowser();
            stepForSettingsPage.InitBrowser();
            stepForTrashPage.InitBrowser();

        }

        [TearDown]
        public void CleanUp()
        {
            stepForMainPage.OpenInBox();
            stepForMainPage.StarredTopMessage();
        }

        [Test]
         [Ignore("ignore")] //13
        public void MarkAsStar()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.StarredTopMessage();
            stepForMainPage.OpenStarPage();
            Assert.IsTrue(stepForMainPage.CheckStarMessage());
            Waiter.Wait();
        }

    }
}
