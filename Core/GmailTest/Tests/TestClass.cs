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
        private const string TOPIC_LETTER_WITH_ATTACH = "letter with attech";
        private const string TOPIC_LETTER_WITHOUT_ATTACH = "hi";
        private const string PATH_TO_SMALL_FILE = @"G:\свадьба.xlsx";
        private const string PATH_TO_BIG_FILE = @"G:\1.rar";
        private const string PATH_TO_SMALL_FILE2 = @"G:\DSC_8250.jpg";
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

        //[TearDown]
        //public void CleanUp()
        //{
        //    stepForLogin.CloseBrowser();
        //}


        [Test]
        [Ignore("ignore")] //1
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
        [Ignore("ignore")] //2
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
            Waiter.Wait();
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
            Assert.IsTrue(stepForMainPage.FindEmailInInbox(TOPIC_LETTER_WITHOUT_ATTACH));

        }

        [Test]
        [Ignore("ignore")] //3
        public void BigFileGmail()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteALetterWithAttach2(USEREMAIL, PATH_TO_BIG_FILE);
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckPresenceOfAlertForFileTooBig());
        }

        [Test]
        [Ignore("ignore")] //4
        public void ThemesGmail()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.OpenThemes();
            stepForSettingsPage.ChangeThemeCustomImage(PATH_TO_SMALL_FILE);
            Assert.IsTrue(stepForSettingsPage.CheckThemes());
        }


        [Test]
        [Ignore("ignore")] //5
        public void SendEmailWithEmoji()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL3, USERPASSWORD3);
            stepForMainPage.WriteLetterWithEmoticonIcon(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckEmojiInEmailBody());
        }


        [Test]
        [Ignore("ignore")] //6
        public void ChangeUserTheme()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.OpenThemes();
            Waiter.Wait();
            stepForSettingsPage.ChooseThemes();
            //выбрать любую тему
        }

        [Test]
         [Ignore("ignore")] //11
        public void MarkItemAsNotASpam()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.MarkTheLetter();
            stepForSpamPage.GoToSpam(SPAMFOLDER);
            Waiter.Wait();
            stepForMainPage.MarkLetterNotSpam();
            Waiter.Wait();
            stepForMainPage.OpenInBox();
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckLetterInBox());
        }

        [Test]
        // [Ignore("ignore")] //12
        public void CheckingSignature()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
          //  stepForMainPage.OpenGeneralSettings();
          //  stepForSettingsPage.EnterSignature(SIGNATURE);
         //   Waiter.Wait();
            stepForMainPage.WriteALetter();
            Waiter.Wait();
          //  stepForMainPage.CheckSignature(SIGNATURE);
           Assert.IsTrue(stepForMainPage.CheckSignature(SIGNATURE));
        }
    }
}
