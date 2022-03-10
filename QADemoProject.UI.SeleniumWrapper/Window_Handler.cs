using NUnit.Framework;
using OpenQA.Selenium;
using QADemoProject.UI.SeleniumWrapper;
using System;
using System.Collections.Generic;
using System.IO;

namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to window
    public class Window_Handler
    {

        public static void Window_Maximize(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                driver.Manage().Window.Maximize();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        public static void Window_Minimize(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                driver.Manage().Window.Minimize();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        public static void Window_FullScreen(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                driver.Manage().Window.FullScreen();
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }
        //public static IReadOnlyCollection<string> GetAllWindowsHandles(IWebDriver driver, bool inputValidation = false)
        //{
        //    IReadOnlyCollection<string> allWindowsHandles{'0'};
        //    try
        //    {
        //     allWindowsHandles = driver.WindowHandles;
        //        return allWindowsHandles;
        //    }
        //    catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
        //    {
        //        return allWindowsHandles;
        //        //ExtentTest test = 
        //        //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
        //        Assert.Fail();


        //    }

        //}


        public static void SwitchWindowsHandles(IWebDriver driver, bool inputValidation = false)
        {
            IReadOnlyCollection<string> allWindowsHandles;
            try
            {
                string winHandleBefore = driver.CurrentWindowHandle;

                //Switch back to original browser (first window)
                driver.SwitchTo().Window(winHandleBefore);
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebDriverTimeoutException)
            {

                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();


            }

        }

        public void MakeScreenshot()
        {
            //var takesscreenshot = Driver.Current as ITakesScreenshot;
            //if (takesscreenshot != null)
            //{
            //    var screenshot = takesscreenshot.GetScreenshot();
            //    var tempfilename = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
            //    screenshot.SaveAsFile(tempfilename, ScreenshotImageFormat.Jpeg);

            //    Console.WriteLine($"screenshot[ file:///{tempfilename} ]screenshot");
            //}
        }

    }
}
