using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;

namespace GmailTest.Tests
{
    [TestFixture]
    public  class SignatureGmail
    {
        StepForLoginPage stepForLogin = new StepForLoginPage();
        StepForMainPage stepForMainPage = new StepForMainPage();
        StemForSpamPage stepForSpamPage = new StemForSpamPage();
        StepsForSettingsPage stepForSettingsPage = new StepsForSettingsPage();
        StepForTrashPage stepForTrashPage = new StepForTrashPage();

        private const string USEREMAIL = "anastasiyaliazhniuk@gmail.com";
        private const string USERPASSWORD = "meniti82";
                  private const string SIGNATURE = "nastya";

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
            stepForMainPage.CloseWindowWithMessage();
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.DeleteSignature();
            // stepForLogin.CloseBrowser();
        }

        [Test]
        [Ignore("ignore")] //12
        public void CheckingSignature()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.OpenGeneralSettings();
            stepForSettingsPage.EnterSignature(SIGNATURE);
            Waiter.Wait();
            stepForMainPage.WriteALetter();
            Waiter.Wait();
            stepForMainPage.CheckSignature(SIGNATURE);
            Assert.IsTrue(stepForMainPage.CheckSignature(SIGNATURE));
        }
    }
}
