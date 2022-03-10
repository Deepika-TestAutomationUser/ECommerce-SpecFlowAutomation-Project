using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;



namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to textbox
    public class TextBox_Handler
    {
        public static void TextBox_SendKeys(IWebDriver driver, By by, string valueToType, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(valueToType);
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
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(valueToType);
            }
        }
        public static void TextBox_ClearText(IWebDriver driver, By by, string valueToType, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                driver.FindElement(by).Clear();
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
                driver.FindElement(by).Clear();
            }
        }
        public static string TextBox_GetElementText(IWebDriver driver, By by, string valueToType, bool inputValidation = false)
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

        public static bool ValidateTextBoxIsVisible(IWebDriver driver, By by, bool inputValidation = false)
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

        public static bool ValidateTextBoxIsEnabled(IWebDriver driver, By by, bool inputValidation = false)
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
        public static string GetTextBoxAttribute(IWebDriver driver, By by, string AttributeToGet, bool inputValidation = false)
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


        //public static void FileUpload(IWebDriver driver, By by, string FilePath, bool inputValidation = false)
        //{
        //    try
        //    {
        //        IWebElement element=driver.FindElement(by);
        //        new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        //        ((RemoteWebElement)element).setFileDetector(new LocalFileDetector());
        //        TextBox_Handler.TextBox_SendKeys(driver, element,FilePath, false);

        //    }
        //    catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
        //    {
        //        //ExtentTest test = 
        //        //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
        //        Assert.Fail();

        //    }
        //    catch (Exception ex) when (ex is StaleElementReferenceException)
        //    {
        //        // find element again and retry
        //        new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        //        return driver.FindElement(by).GetAttribute(AttributeToGet);
        //    }
        //}




    }
}
