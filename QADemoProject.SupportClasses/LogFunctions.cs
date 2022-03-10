using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QADemoProject.SupportClasses
{
    /// <summary>
    /// These methods allow writing additional lines to the SpecFlow log file
    /// The class types correspond to CSS that has been added to allow the colors to display in the output
    /// </summary>
    public static class LogFunctions
    {

        /// <summary>
        /// Write an error to the log file, these will show in red text
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void WriteWarning(string message)
        {
            message = "<div class=\"warningMessage\">" + message + "</div>";
            Console.WriteLine(message);
        }
        /// <summary>
        /// Write an error to the log file, with default SpecRun report template these will show in red text
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void WriteError(string message)
        {
            message = "<div class=\"errorMessage\">" + message + "</div>";
            Console.WriteLine(message);
        }
        /// <summary>
        /// Write a success or info message to the log file, with default SpecRun report template these will show in green text
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void WriteInfo(string message)
        {
            message = "<div class=\"infoMessage\">" + message + "</div>";
            Console.WriteLine(message);
        }

        /// <summary>
        /// Takes a screenshot of current page
        /// Should be called during cleanup, if an error occurred. 
        /// </summary>
        public static void TakeScreenshot(string featureInfoTitle, string scenarioInfoTitle, IWebDriver webDriver)
        {
            try
            {
                var scenarioTitle = scenarioInfoTitle.Replace("/", string.Empty);
                var date = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var thread = Thread.CurrentThread;
                //var fileNameBase = featureInfoTitle + "_" + scenarioTitle + "_" + thread.ManagedThreadId + "_" + date;
                var fileNameBase = scenarioTitle + "_" + thread.ManagedThreadId + "_" + date;

                var subDirectory = Path.Combine(Directory.GetCurrentDirectory());
                if (!Directory.Exists(subDirectory))
                    Directory.CreateDirectory(subDirectory);

                var screenShotsDirectory = Path.Combine(subDirectory, "ScreenShots");
                if (!Directory.Exists(screenShotsDirectory))
                    Directory.CreateDirectory(screenShotsDirectory);
                var takesScreenshot = webDriver as ITakesScreenshot;

                if (takesScreenshot == null) return;
                var screenshot = takesScreenshot.GetScreenshot();

                var screenshotFilePath = Path.Combine(screenShotsDirectory, fileNameBase + ".PNG");

                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                Console.WriteLine(@"Screenshot: {0}", new Uri(screenshotFilePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Error while taking screenshot: {0}", ex);
            }
        }


       
    }
}
