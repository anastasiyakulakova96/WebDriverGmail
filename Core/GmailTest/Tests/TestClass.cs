using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;

namespace WebDriver.Tests
{
    [TestFixture]
    public class TestClass
    {
        StepForLoginPage stepForLogin = new StepForLoginPage();
        StepForMainPage stepForMainPage = new StepForMainPage();
        StemForSpamPage stepForSpamPage = new StemForSpamPage();
        StepsForSettingsPage stepForSettingsPage = new StepsForSettingsPage();
        StepForTrashPage stepForTrashPage = new StepForTrashPage();

        private const string USEREMAIL = "anastasiyaliazhniuk@gmail.com";
        private const string USERPASSWORD = "meniti82";
        private const string ADDRESSEE = "s.lezhnyuk@gmail.com";
        private const string USEREMAIL2 = "s.lezhnyuk@gmail.com";
        private const string USERPASSWORD2 = "m1am1g0s";
        private const string SPAMFOLDER = "in:spam";
        private const string USEREMAIL3 = "nastyakylakova96@gmail.com";
        private const string USERPASSWORD3 = "meniti82";
        private const string SETTINGPAGE = "fwdandpop";


        [SetUp]
        public void Init()
        {
            stepForLogin.InitBrowser();
            stepForMainPage.InitBrowser();
            stepForSpamPage.InitBrowser();
            stepForSettingsPage.InitBrowser();
            stepForTrashPage.InitBrowser();

        }

        //[TearDown]
        //public void CleanUp()
        //{
        //    stepForLogin.CloseBrowser();
        //}


        [Test]
        [Ignore("ignore")]
        public void SpamGmail()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.WriteALetter(ADDRESSEE);
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USEREMAIL2, USERPASSWORD2);
            stepForMainPage.MarkTheLetter();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail(USERPASSWORD);
            stepForMainPage.WriteALetter(ADDRESSEE);
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail2(USERPASSWORD2);
            stepForSpamPage.GoToSpam(SPAMFOLDER);
            Waiter.Wait();
            Assert.True(stepForSpamPage.AssertSpam(USEREMAIL), "all right");

            // steps.NotASpam();
            //  steps.CloseBrowser();
            // steps.InitBrowser();
        }

        [Test]
        // [Ignore("ignore")]
        public void ForwardGmail()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL2, USERPASSWORD2);
            stepForMainPage.OpenSettings();
            stepForSettingsPage.SetForwardingToUserInSetting(USEREMAIL3);
            stepForSettingsPage.SentEmail();
            Waiter.Wait();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            Waiter.Wait();
            stepForMainPage.OpenMessage();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForMainPage.OpenSettings();
            stepForSettingsPage.ForwardACopyOfIncomingMailTo();
            stepForSettingsPage.CreateNewFilter();
            stepForSettingsPage.FillInNewFilterFrom(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut222();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.WriteALetterWithAttach(USEREMAIL2);
            Waiter.Wait();
            stepForMainPage.WriteALetter(USEREMAIL2);
            Waiter.Wait();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForTrashPage.OpenTrash();
            //Assert.assertTrue(trash.findEmailInTrash(topic));
            Assert.IsTrue(stepForTrashPage.FindEmailInTrash("hi"));
          

        }
    }
}
