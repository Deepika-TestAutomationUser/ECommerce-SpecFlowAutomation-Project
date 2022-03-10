using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace QADemoProject.UI.SeleniumWrapper
{
    public class Frame_Handler_Wrapper
    {
        //This class has all the method related to frame element

        public static void SwitchTo_FrameByIndex(IWebDriver driver, int index, bool inputValidation = false)
        {
            try
            {
                driver.SwitchTo().Frame(index);
            }
            catch (Exception ex) when (ex is NoSuchFrameException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        public static void SwitchTo_FrameByName(IWebDriver driver, string name, bool inputValidation = false)
        {
            try
            {
                driver.SwitchTo().Frame(name);
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        public static void SwitchTo_FrameByElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(by));
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void SwitchTo_DefaultContent(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void SwitchTo_ActiveElement(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                driver.SwitchTo().ActiveElement();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void SwitchTo_ParentFrame(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                driver.SwitchTo().ParentFrame();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }



    }
}