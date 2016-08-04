using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;

namespace Core.Driver
{
    public class Driver
    {
        private static IWebDriver _driver;

        private Driver() { }

        public static IWebDriver GetDriver(string _browser)
        {
            if (_driver == null)
            {
                _driver = CreatDriver(_browser);
            }
            return _driver;
        }


        public static IWebDriver CreatDriver(string _browser)
        {
            switch (_browser)
            {
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    return new FirefoxDriver();
            }
        }

        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }

        public static void QuitDriver()
        {
            _driver.Quit();
        }
    }
}

