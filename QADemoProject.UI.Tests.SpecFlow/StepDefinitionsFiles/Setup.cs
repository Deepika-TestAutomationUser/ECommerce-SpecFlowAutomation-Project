using System;
using TechTalk.SpecFlow;
using Unity;
using Unity.Lifetime;
using System.Linq;
using System.IO;
using QADemoProject.UI.SeleniumWrapper;
using QADemoProject.PageObjects;
using PathFinders.SupportClasses;
using QADemoProject.SupportClasses;
using System.Diagnostics;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Text;
using TechTalk.SpecFlow.Tracing;

namespace QADemoProject.UI.Tests.SpecFlow
{
    /// <summary>
    /// Spec Run start up to create the web driver, initialize log values, and get information from the Interface.
    /// </summary>
    [Binding]
    public class SpecRunSetup
    {
        private static BrowserTypes _browserType;

        /// <summary>
        /// All setup parameters run before each feature
        /// </summary>
        [BeforeFeature]
        public static void Startup(FeatureContext featureContext)
        {
            LogFunctions.WriteInfo("Starting Feature : " + featureContext.FeatureInfo.Title);
            DeleteFilesAndDirectory();
        }




        public static void DeleteFilesAndDirectory()
        {
            string directoryPath = "";
            if (Directory.Exists(@directoryPath))
            {
                Directory.Delete(@directoryPath, true);//cleanup created folder which has any content inside it.
                //true ensures that folder is deleted even if it is not empty. 
            }

        }
        /// <summary>
        /// All setup parameters to run before each scenario
        /// </summary>
        [BeforeScenario]
        public static void ScenarioSetup(ScenarioContext scenarioContext)
        {
           // Driver.TestName = scenarioContext.ScenarioInfo.Title;

            Driver.StartBrowser(_browserType);
            UnityContainerFactory.GetContainer()
                .RegisterType<Page, LoginPage>("LoginPage", new ContainerControlledLifetimeManager());
            UnityContainerFactory.GetContainer()
                 .RegisterType<Page, MyAccountPage>("MyAccountPage", new ContainerControlledLifetimeManager());
            UnityContainerFactory.GetContainer()
                 .RegisterType<Page, CheckOutPage>("CheckOutPage", new ContainerControlledLifetimeManager());

            UnityContainerFactory.GetContainer().RegisterInstance(Driver.Browser);

        }

        /// <summary>
        /// Scenario Cleanup will be run after each scenario is executed.
        /// </summary>
        [AfterScenario]
        public static void ScenarioCleanup(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            
            Driver.QuitBrowser();
            //Runtime.getRuntime().exec("taskkill /F /IM chromedriver.exe /T");
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }

        }

        private static void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Jpeg);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}