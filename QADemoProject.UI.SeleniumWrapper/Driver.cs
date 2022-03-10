using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to driver initialization
    public static class Driver
    {

        private static IWebDriver driver;
        private static WebDriverWait browserWait;
        public static IWebDriver Browser
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException("");
                }
                return driver;

            }


            private set { driver = value; }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {

                if (browserWait == null || driver == null)
                {
                    throw new NullReferenceException("");
                }
                return browserWait;

            }

            private set { browserWait = value; }
        }

        public static void StartBrowser(BrowserTypes browserType=BrowserTypes.Chrome,int defaultTimeOut=30)
        {
            switch(browserType)
            {
                case BrowserTypes.Chrome:
                    StartChromeWebDriver();
                    break;
                case BrowserTypes.InterNetExplorer:
                    StartIEWebDriver();
                    break;

            }

            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        private static void StartChromeWebDriver()
        {

            var path = Directory.GetCurrentDirectory().Replace("\\TestResults", "");
            path = path.Replace("\\TestResults", "");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--ignore-certificate-errors");
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("download.default_directory", "");
            options.AddUserProfilePreference("intl.accept_languages", "nl");
            options.AddUserProfilePreference("diable-popup-blocking", "true");
            Browser = new ChromeDriver(GetBasePath, options, TimeSpan.FromMinutes(3));

        }

        private static void StartIEWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--ignore-certificate-errors");
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("download.default_directory", "");
            options.AddUserProfilePreference("intl.accept_languages", "nl");
            options.AddUserProfilePreference("diable-popup-blocking", "true");

            Browser = new ChromeDriver(GetBasePath, options, TimeSpan.FromMinutes(3));


        }

        private static string GetBasePath
        {
            get
            {
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                basePath = basePath;
                return basePath;
            }
        }

        public static void QuitBrowser()
        {
            driver.Quit();
        }


    }
}
