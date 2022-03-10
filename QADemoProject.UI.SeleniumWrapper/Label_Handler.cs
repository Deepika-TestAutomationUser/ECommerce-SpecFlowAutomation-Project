using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace QADemoProject.UI.SeleniumWrapper
{//This class has all the method related to label element
    public class Label_Handler
    {


        public static string Label_GetElementText(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Text;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Text;
            }
        }

        public static int GetElementCount(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElements(by).Count;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return 0;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElements(by).Count;
            }
        }
        public static IWebElement GetElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by);
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return driver.FindElement(by);
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by);
            }
        }
        public static IList<OpenQA.Selenium.IWebElement> GetListOfElements(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElements(by);
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElements(by);
            }
        }

        public static bool ValidateLabelIsVisible(IWebDriver driver, By by, bool inputValidation = false)
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


        public static string GetLabelAttribute(IWebDriver driver, By by, string AttributeToGet, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).GetAttribute(AttributeToGet);
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).GetAttribute(AttributeToGet);
            }
        }


    }
}
