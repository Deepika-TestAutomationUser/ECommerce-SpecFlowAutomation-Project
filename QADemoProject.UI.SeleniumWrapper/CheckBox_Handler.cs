using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to check box element
    public class CheckBox_Handler
    {

        public static bool ValidateCheckBoxIsVisible(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Displayed;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return false;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Displayed;
            }
        }
        public static bool ValidateCheckBoxIsEnabled(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Enabled;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return false;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Enabled;
            }
        }


        public static bool ValidateCheckBoxIsSelected(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Selected;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return false;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Selected;
            }
        }

        public static void SelectCheckBox(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                if (ValidateCheckBoxIsSelected(driver, by, true) != true)
                {
                    driver.FindElement(by).Click();
                }
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();

            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                if (ValidateCheckBoxIsSelected(driver, by, true) != true)
                {
                    driver.FindElement(by).Click();
                }
            }
        }
        public static void UnSelectCheckBox(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                if (ValidateCheckBoxIsSelected(driver, by, true) == true)
                {
                    driver.FindElement(by).Click();
                }
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();

            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                if (ValidateCheckBoxIsSelected(driver, by, true) == true)
                {
                    driver.FindElement(by).Click();
                }
            }
        }


    }
}
