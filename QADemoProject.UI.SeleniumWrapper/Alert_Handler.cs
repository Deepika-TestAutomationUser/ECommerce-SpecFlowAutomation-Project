using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to alert popup
    public class Alert_Handler
    {

     

        public static void Alert_Accept(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex) when (ex is NoAlertPresentException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }
            catch (Exception ex) when (ex is UnhandledAlertException)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Accept();
            }

        }

        public static void Alert_Dismiss(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception ex) when (ex is NoAlertPresentException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }
            catch (Exception ex) when (ex is UnhandledAlertException)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Dismiss();

            }

        }

        public static string Alert_GetAlertText(IWebDriver driver, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                return driver.SwitchTo().Alert().Text;
            }
            catch (Exception ex) when (ex is NoAlertPresentException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }
            catch (Exception ex) when (ex is UnhandledAlertException)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                return driver.SwitchTo().Alert().Text;

            }

        }


        public static void Alert_SendKeys(IWebDriver driver, string valueToSend, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().SendKeys(valueToSend);
            }
            catch (Exception ex) when (ex is NoAlertPresentException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();

            }
            catch (Exception ex) when (ex is UnhandledAlertException)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().SendKeys(valueToSend);

            }

        }

        public static void Alert_SendAuthentication(IWebDriver driver, string userName, string password, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().SetAuthenticationCredentials(userName, password);
            }
            catch (Exception ex) when (ex is NoAlertPresentException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform Launch URL + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();

            }
            catch (Exception ex) when (ex is UnhandledAlertException)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().SetAuthenticationCredentials(userName, password);

            }

        }

    }
}
