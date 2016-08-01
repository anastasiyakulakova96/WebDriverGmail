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
            stepForLogin.LoginGmail(USEREMAIL2, USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
            stepForMainPage.MarkTheLetter();
            Waiter.Wait();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail(USERPASSWORD2);
            stepForMainPage.WriteALetter(USEREMAIL);
            Waiter.Wait();
            stepForMainPage.LogOut2();
            stepForLogin.LoginGmail2(USERPASSWORD);
            stepForSpamPage.GoToSpam(SPAMFOLDER);
            Waiter.Wait();
            Assert.True(stepForSpamPage.AssertSpam(USEREMAIL2));
            Waiter.Wait();
            stepForSpamPage.OpenLetterAndMarkNotSpam();

            // steps.NotASpam();
            //  steps.CloseBrowser();
            // steps.InitBrowser();
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
          stepForSpamPage.MarkLetterNotSpam();
            Waiter.Wait();
            stepForMainPage.OpenInBox();
            Waiter.Wait();
            Assert.IsTrue(stepForMainPage.CheckLetterInBox());
        }


        [Test]
       // [Ignore("ignore")] //14
        public void VacationGmail()
        {
            stepForLogin.OpenStartPage();
            stepForLogin.LoginGmail(USEREMAIL, USERPASSWORD);
         //   stepForSettingsPage.VacationResponderOn();
        }
        


    }
}
