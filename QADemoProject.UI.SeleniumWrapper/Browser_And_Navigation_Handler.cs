using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to browser navigation
    public class Browser_And_Navigation_Handler
    {

        //private readonly FeatureContext _featurecontext;
        //private readonly ScenarioContext _scenariocontext;
        //public Wrapper(FeatureContext _featurecontext, ScenarioContext _scenariocontext)
        //{
        //    this._featurecontext = _featurecontext;
        //    this._scenariocontext = _scenariocontext;
        //}




        public static void LaunchURL(IWebDriver driver, string URL, bool inputValidation = false)
        {
            try
            {
                driver.Navigate().GoToUrl(URL);
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void RefreshPage(IWebDriver driver, string URL, bool inputValidation = false)
        {
            try
            {
                driver.Navigate().Refresh();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        public static void Page_NavigateForward(IWebDriver driver, string URL, bool inputValidation = false)
        {
            try
            {
                driver.Navigate().Forward();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        public static void Page_NavigateBack(IWebDriver driver, string URL, bool inputValidation = false)
        {
            try
            {
                driver.Navigate().Back();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }


        public static string GetPageURL(IWebDriver driver, bool inputValidation = true)
        {
            try
            {

                return driver.Url;
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }

        }
        public static string GetPageTitle(IWebDriver driver, bool inputValidation = true)
        {
            try
            {

                return driver.Title;
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }

        }
        public static string GetPageSource(IWebDriver driver, bool inputValidation = true)
        {
            try
            {

                return driver.PageSource; ;
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }

        }
        public static void CloseCurrentDriver(IWebDriver driver, bool inputValidation = true)
        {
            try
            {

                driver.Close();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                driver.Close();
            }

        }
        public static void CloseAllDriver(IWebDriver driver, bool inputValidation = true)
        {
            try
            {

                driver.Quit();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                driver.Quit();
            }

        }

    }
}
