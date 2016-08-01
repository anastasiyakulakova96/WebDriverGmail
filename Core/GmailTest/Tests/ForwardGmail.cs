using NUnit.Framework;
using WebDriver.Steps;
using WebDriverLibrary.Steps;
using NUnit;
using GmailTest.Steps;

namespace GmailTest.Tests
{
    [TestFixture]
    public class ForwardGmail
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
        private const string TOPIC_LETTER_WITH_ATTACH = "letter with attech";
        private const string TOPIC_LETTER_WITHOUT_ATTACH = "hi";
        private const string PATH_TO_SMALL_FILE = @"d:\свадьба.xlsx";
        private const string PATH_TO_BIG_FILE = @"d:\1.rar";
        private const string PATH_TO_SMALL_FILE2 = @"d:\DSC_8250.jpg";
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

        [Test]
        [Ignore("ignore")] //2
        public void ForwardGmailTest()
        {
            //stepForLogin.OpenStartPage();
            //stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
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
            Waiter.Wait();
            stepForSettingsPage.OpenFilterPage();
            stepForSettingsPage.CreateNewFilter();
            stepForSettingsPage.FillInNewFilterFrom(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut222();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.WriteALetterWithAttach(USEREMAIL2, PATH_TO_SMALL_FILE);
            Waiter.Wait();
            stepForMainPage.WriteALetter(USEREMAIL2);
            Waiter.Wait();
            stepForMainPage.LogOut2();
            Waiter.Wait();
            stepForLogin.LoginGmail(USERPASSWORD2);
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.FindEmailInInbox(TOPIC_LETTER_WITHOUT_ATTACH));
            stepForTrashPage.OpenTrash();
            Waiter.Wait();
            Assert.IsTrue(stepForTrashPage.FindEmailInTrash(TOPIC_LETTER_WITH_ATTACH));
            Waiter.Wait();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail2(USERPASSWORD3);
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.FindEmailInInbox(TOPIC_LETTER_WITHOUT_ATTACH));
        }

        [TearDown]
        public void Clean()
        {
            Waiter.Wait();
            stepForMainPage.LogOut2();
            Waiter.Wait();
            stepForLogin.LoginGmail(USERPASSWORD2);
            Waiter.Wait();
            stepForMainPage.OpenSettings();
            stepForSettingsPage.DeleteEmail();
            Waiter.Wait();
            stepForSettingsPage.OpenFilterPage();
            Waiter.Wait();
            stepForSettingsPage.DeleteFilter();

        }

    }
}
